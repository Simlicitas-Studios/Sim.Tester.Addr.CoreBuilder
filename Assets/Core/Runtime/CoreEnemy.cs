using UnityEngine;

namespace Core
{
    public class CoreEnemy : MonoBehaviour
    {
        public CoreEnemyStats Stats;

        private void Awake()
        {
            Debug.Log($"CoreEnemy initialized with {Stats?.Health ?? 0} HP");
        }
    }
}