using System;
using UnityEngine;

namespace Characters.Characters
{
    public class CharacterGroundDetector : MonoBehaviour
    {
        [SerializeField] private float detectionRadius = 0.1f;
        [SerializeField] private LayerMask groundLayer;
        private readonly Collider[] _colliders = new Collider[1];
        
        public bool IsGrounded => Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, _colliders, groundLayer) != 0;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}