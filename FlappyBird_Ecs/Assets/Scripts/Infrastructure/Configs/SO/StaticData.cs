using UnityEngine;

namespace FlappyBird.Infrastructure.Configs.SO
{
    [CreateAssetMenu(menuName = "Configurations/StaticData", fileName = "StaticData")]
    public class StaticData : ScriptableObject
    {
        public GameObject BirdPrefab = null;
    }
}