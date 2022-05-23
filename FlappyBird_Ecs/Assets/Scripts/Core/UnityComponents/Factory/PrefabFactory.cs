using FlappyBird.Core.Components;
using FlappyBird.Core.UnityComponents.MonoProvider.Base;
using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird.Core.UnityComponents.Factory
{
    public class PrefabFactory : MonoBehaviour
    {
        private EcsWorld _world = null;

        public void SetWorld(EcsWorld world)
        {
            _world = world;
        }

        public void Create(SpawnPrefab spawnPrefab)
        {
            GameObject tempObject = Instantiate(spawnPrefab.Prefab, spawnPrefab.Position, spawnPrefab.Rotation, spawnPrefab.Parent);
            var monoEntity = tempObject.GetComponent<MonoEntity>();

            if (monoEntity == null)
                return;

            EcsEntity ecsEntity = _world.NewEntity();
            monoEntity.Set(ref ecsEntity);
        }
    }
}