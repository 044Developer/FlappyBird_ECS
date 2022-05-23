using FlappyBird.Core.UnityComponents.Factory;
using UnityEngine;

namespace FlappyBird.Core.UnityComponents.Data
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private PrefabFactory _prefabFactory = null;
        
        public PrefabFactory PrefabFactory => _prefabFactory;
    }
}