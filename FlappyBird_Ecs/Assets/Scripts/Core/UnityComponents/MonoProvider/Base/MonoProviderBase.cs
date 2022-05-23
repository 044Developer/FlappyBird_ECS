using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird.Core.UnityComponents.MonoProvider.Base
{
    [RequireComponent(typeof(MonoEntity))]
    public abstract class MonoProviderBase : MonoBehaviour
    {
        public abstract void Set(ref EcsEntity ecsEntity);
    }
}