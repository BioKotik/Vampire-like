using System;
using Intefaces;
using SO.Scripts;
using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour, ICharacter
    {
        [SerializeField]
        private PlayerConfigs stats;
        [SerializeField]
        private float moveSpeed;

        private BaseCharacterData characterData;
        private Vector3 change;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            characterData = (BaseCharacterData)stats.GetData();
        }

        private void Update()
        {
            change = Vector3.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
            
            Move(change);
        }
        
        public void Move(Vector3 direction)
        {
            transform.position += change * (moveSpeed * Time.deltaTime);
        }

        public void Attack()
        {
            
        }

        public void TakeDamage(float damage)
        {
            characterData.heatlhPoints -= damage;
            
            if (characterData.heatlhPoints < 0)
            {
                Death();
            }
        }

        public void Death()
        {
            this.gameObject.SetActive(false);
        }
    }
}