using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Mobiiliesimerkki
{
    public class Move : MonoBehaviour
    {
        [SerializeField]
        private int _min;

        [SerializeField]
        private int _max;

        private float _minX;
        private float _maxX;

        private float _direction = 1;

        private void Start()
        {
            _minX = transform.position.x;
            _minX += _min;

            _maxX = transform.position.x;
            _maxX += _max;
        }

        private void Update()
        {
            if (_direction > 0 && transform.position.x >= _maxX
                || _direction < 0 && transform.position.x <= _minX)
            {
                // Flip direction.
                _direction *= -1;
            }

            Vector3 movement = Vector3.right * _direction * Time.deltaTime;
            transform.Translate(movement);
        }
    }
}