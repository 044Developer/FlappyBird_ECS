using FlappyBird.Core.Components.Common.Input;
using FlappyBird.Core.Systems;
using FlappyBird.Core.UnityComponents.Data;
using FlappyBird.Infrastructure.Configs.SO;
using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird.Core 
{
    sealed class EcsStartup : MonoBehaviour
    {
        [SerializeField] private StaticData _staticData = null;
        [SerializeField] private SceneData _sceneData = null;
        
        private EcsWorld _world = null;
        private EcsSystems _systems = null;
        private EcsSystems _fixedSystems = null;

        private void Start() 
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world, "UpdateSystems");
            _fixedSystems = new EcsSystems(_world, "FixedUpdateSystems");
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            _systems
                .OneFrame<SpaceKeyDownTag>()
                .Add(new KeyboardInputSystem())
                .Add(new BirdSpawnSystem())
                .Add(new SpawnSystem())
                .Inject(_staticData)
                .Inject(_sceneData)
                .Init();
            
            _fixedSystems
                .Add(new CoreGamePlaySystem())
                .Add(new MovableSystem())
                .Inject(_staticData)
                .Init();
        }

        private void Update() 
        {
            _systems?.Run();
        }

        private void FixedUpdate()
        {
            _fixedSystems?.Run();
        }

        private void OnDestroy() 
        {
            if (_fixedSystems != null)
            {
                _fixedSystems.Destroy();
                _fixedSystems = null;
            }

            if(_systems != null) 
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}