using UnityEngine;

namespace SO.Scripts
{
    public class BaseCharaterConfigs : ScriptableObject
    {
        [SerializeField]
        protected float heatlhPoints;
        [SerializeField]
        protected float movementSpeed;

        public virtual ICharacterBaseData GetData()
        {
            var result = new BaseCharacterData
            {
                heatlhPoints = this.heatlhPoints,
                movementSpeed = this.movementSpeed
            };

            return result;
        }
    }
}