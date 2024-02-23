using UnityEngine;

namespace Mobiiliesimerkki
{
	public class TargetMover : MonoBehaviour
	{
		[SerializeField] private float _speed = 5f;
		[SerializeField] private Transform _target;

		private Rigidbody2D _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		private void FixedUpdate()
		{
			Vector2 direction = (_target.position - transform.position).normalized;
			_rigidbody.velocity = direction * _speed;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.transform == _target)
			{
				Destroy(gameObject);
			}
		}
	}
}