using UnityEngine;

namespace Mobiiliesimerkki
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PhysicsMover : MonoBehaviour
	{
		[SerializeField]
		private float _speed = 1;

		private Rigidbody2D _rb2D;
		private InputReader _inputReader;

		private bool _isJumping = false;
		private Vector2 _direction = Vector2.zero;

		private void Awake()
		{
			_rb2D = GetComponent<Rigidbody2D>();
			_inputReader = GetComponent<InputReader>();
		}

		private void Update()
		{
			_direction = _inputReader.Movement;

			bool isJumping = _inputReader.Jump;
			if (!_isJumping && isJumping)
			{
				_isJumping = true;
			}
		}

		private void FixedUpdate()
		{
			Move(_direction);
			if (_isJumping)
			{
				Jump();

				// Jump input consumed
				_isJumping = false;
			}
		}

		private void Jump()
		{
			Debug.Log("Jumping");
		}

		private void Move(Vector2 direction)
		{
			Vector2 velocity = _rb2D.velocity;
			velocity.x = direction.x * _speed;
			_rb2D.velocity = velocity;
		}
	}
}