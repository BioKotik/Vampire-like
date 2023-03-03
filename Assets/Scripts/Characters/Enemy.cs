using System;
using System.Collections;
using Intefaces;
using SO.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Characters
{
    public class Enemy : MonoBehaviour, ICharacter
    {
        [SerializeField]
        private EnemyConfigs stats;
        
        private Player player;
        private EnemyCharacterData characterData;

        [SerializeField] private float startOffset;
        [SerializeField] private float endOffset;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float minUpdateTargetDelay;
        [SerializeField] private float maxUpdateTargetDelay;

        private float elapsedTime;
        private float updateTargetDelay;
        private bool isChaseEnabled;

        private Vector3 startPosition;
        private Vector3 currentPosition;
        private Vector3 velocity;
        private Vector3 targetDirection;

        public void Start()
        {
            Init();
        }

        private void Init()
        {
            isChaseEnabled = false;

            player = FindObjectOfType<Player>();
            
            characterData = (EnemyCharacterData)stats.GetData();
        }
        
        private void Update()
        {
            if (isChaseEnabled)
            {
                ChasePlayer();

            }
        }
        
        public void SetChaseEnabled(bool state)
        {
            Debug.Log($"[Enemy]: Is Chase -> {state}");
            isChaseEnabled = state;
        }
        
        public void Move(Vector3 direction)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            
            if (distance > 0.2f)
            {
                float randomX = Random.Range(startOffset, endOffset);
                float randomY = Random.Range(startOffset, endOffset);

                //var offset = new Vector3(randomX, randomY, 0);
                var offset = Vector3.zero;
                Debug.DrawLine(transform.position, transform.position + (direction + offset).normalized, Color.yellow);
                transform.position += (direction + offset).normalized * (Time.deltaTime * moveSpeed);
            }
        }

        private void ChasePlayer()
        {
            if (Vector3.Distance(transform.position, player.transform.position) > characterData.attackRange)
            {
                UpdatePlayerDirection();
                Move(targetDirection);
            }
            else
            {
                Attack();
            }
        }

        private void UpdatePlayerDirection()
        {
            if (player == null)
            {
                Debug.Log($"[Enemy]: Player is null /{gameObject.name}/");
            }
            
            Vector3 offset = Vector3.zero;

            if (elapsedTime == 0)
            {
                float randomX = Random.Range(startOffset, endOffset);
                float randomY = Random.Range(startOffset, endOffset);

                offset = new Vector3(randomX, randomY, 0);
                targetDirection = player.transform.position + offset;
                targetDirection = (targetDirection - transform.position).normalized;

                updateTargetDelay = Random.Range(minUpdateTargetDelay, maxUpdateTargetDelay);
            }
            
            if (elapsedTime <= updateTargetDelay)
            {
                elapsedTime += Time.deltaTime;
            }
            else
            {
                elapsedTime = 0;
            }
        }

        public void Attack()
        {
            player.TakeDamage(characterData.damage);
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