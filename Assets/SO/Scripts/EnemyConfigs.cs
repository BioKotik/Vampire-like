using UnityEngine;

namespace SO.Scripts
{
    [CreateAssetMenu(fileName = "Enemy Statistics", menuName ="ScriptableObjects/EnemyStatistics", order = 0)]
    public class EnemyConfigs : BaseCharaterConfigs
    {
        [SerializeField] private float attackRange;
        [SerializeField] private float damage;

        public override ICharacterBaseData GetData()
        {
            var result = new EnemyCharacterData()
            {
                heatlhPoints = this.heatlhPoints,
                movementSpeed = this.movementSpeed,
                attackRange = this.attackRange,
                damage = this.damage
            };

            return result;
        }
    }
}