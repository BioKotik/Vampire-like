using System;
using Characters;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerDebugInput : MonoBehaviour
    {
        [SerializeField] private Player player;
        private void Start()
        {
            throw new NotImplementedException();
        }

        private void Update()
        {
            var change = Vector3.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");

            player.Move(change);
        }
    }
}