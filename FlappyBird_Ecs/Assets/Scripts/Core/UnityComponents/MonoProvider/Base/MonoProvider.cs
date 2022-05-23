using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird.Core.UnityComponents.MonoProvider.Base
{
    public class MonoProvider<T> : MonoProviderBase where T : struct
    {
        public T Value;

        public override void Set(ref EcsEntity ecsEntity)
        {
            if (ecsEntity.Has<T>())
                return;

            ecsEntity.Get<T>() = Value;
        }
    }
}