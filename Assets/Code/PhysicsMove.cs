using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobiiliesimerkki
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PhysicsMove : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _targetPosition;

        [SerializeField]
        private float _offset;

        private Rigidbody2D _rb;
        private bool _isTargetReached = false;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_isTargetReached)
            {
                return;
            }

            Vector3 movement = (_targetPosition - transform.position);
            if (movement.sqrMagnitude > _offset * _offset)
            {
                movement = movement.normalized;
                movement *= Time.fixedDeltaTime;

                _rb.MovePosition(_rb.position + (Vector2)movement);
            }
            else
            {
                _isTargetReached = true;
            }
        }
    }
}