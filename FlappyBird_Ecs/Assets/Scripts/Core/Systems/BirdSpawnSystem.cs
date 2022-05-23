using FlappyBird.Core.Components;
using FlappyBird.Infrastructure.Configs.SO;
using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird.Core.Systems
{
    public class BirdSpawnSystem : IEcsInitSystem
    {
        private EcsWorld _world = null;
        private StaticData _staticData = null;
        
        public void Init()
        {
            _world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab
            {
                Prefab = _staticData.BirdPrefab,
                Position = Vector3.zero,
                Rotation = Quaternion.identity,
                Parent = null
            };
        }
    }
}