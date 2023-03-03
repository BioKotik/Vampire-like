using Characters;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyDebugInput : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;
        private bool isChaseEnabled;
        private void Start()
        {
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isChaseEnabled = !isChaseEnabled;

                enemy.SetChaseEnabled(isChaseEnabled);
            }
        }
    }
}