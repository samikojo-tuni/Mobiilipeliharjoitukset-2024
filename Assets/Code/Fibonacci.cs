using UnityEngine;

namespace Mobiiliesimerkki
{
    public class Fibonacci : MonoBehaviour
    {
        private int _current = 0;
        private int _next = 1;

        private const int MaxNumber = 1000;

        private void Update()
        {
            if (_current < MaxNumber)
            {
                Debug.Log(_current);
                int temp = _next;
                _next = _current + _next;
                _current = temp;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}