using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "SomeEnemyStats", menuName = "Sim/Core/Enemy Stats", order = 0)]
    public class CoreEnemyStats : ScriptableObject
    {
        public int Health;
    }
}