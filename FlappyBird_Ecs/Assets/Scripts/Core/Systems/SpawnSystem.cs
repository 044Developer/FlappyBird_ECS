using FlappyBird.Core.Components;
using FlappyBird.Core.UnityComponents.Data;
using FlappyBird.Core.UnityComponents.Factory;
using Leopotam.Ecs;

namespace FlappyBird.Core.Systems
{
    public class SpawnSystem : IEcsPreInitSystem, IEcsRunSystem
    {
        private EcsWorld _world = null;
        private SceneData _sceneData = null;

        private EcsFilter<SpawnPrefab> _spawnFilter = null;
        private PrefabFactory _prefabFactory = null;
        
        public void PreInit()
        {
            _prefabFactory = _sceneData.PrefabFactory;
            _prefabFactory.SetWorld(_world);
        }

        public void Run()
        {
            if (_spawnFilter.IsEmpty())
                return;

            foreach (int index in _spawnFilter)
            {
                ref var entity = ref _spawnFilter.GetEntity(index);
                ref var spawnPrefab = ref entity.Get<SpawnPrefab>();
                _prefabFactory.Create(spawnPrefab);
                entity.Del<SpawnPrefab>();
            }
        }
    }
}