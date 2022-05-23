using FlappyBird.Core.Components.Common.Prefab;
using Leopotam.Ecs;

namespace FlappyBird.Core.UnityComponents.MonoProvider.Base
{
    public class MonoEntity : MonoProviderBase
    {
        private EcsEntity _ecsEntity = EcsEntity.Null;
        private MonoProviderBase[] _monoProviders = null;

        public MonoProvider<T> Get<T>() where T : struct    
        {
            foreach (MonoProviderBase providerBase in _monoProviders)
            {
                if (providerBase is MonoProvider<T> provider)
                {
                    return provider;
                }
            }

            return null;
        }

        public override void Set(ref EcsEntity ecsEntity)
        {
            _ecsEntity = ecsEntity;
            _monoProviders = GetComponents<MonoProviderBase>();

            foreach (MonoProviderBase provider in _monoProviders)
            {
                if (provider is MonoEntity)
                    continue;
                
                provider.Set(ref ecsEntity);
            }

            _ecsEntity.Get<GameObjectProvider>() = new GameObjectProvider { Value = gameObject };
            _ecsEntity.Get<PositionProvider>() = new PositionProvider { Value = transform.position };
            _ecsEntity.Get<RotationProvider>() = new RotationProvider { Value = transform.rotation };
        }
    }
}