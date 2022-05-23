using UnityEngine;

namespace FlappyBird.Core.Components
{
    public struct SpawnPrefab
    {
        public GameObject Prefab;
        public Vector3 Position;
        public Quaternion Rotation;
        public Transform Parent;
    }
}