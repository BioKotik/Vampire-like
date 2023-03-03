using UnityEngine;

namespace Intefaces
{
    public interface ICharacter
    {
        void Move(Vector3 direction);
        void Attack();
        void TakeDamage(float damage);
        void Death();
    }
}

