using UnityEngine;

namespace Mobiiliesimerkki
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PhysicsMover : MonoBehaviour
	{
		#region Member variables
		[SerializeField]
		private float _speed = 1;

		[SerializeField]
		private float _acceleration = 1;

		[SerializeField]
		private float _jumpForce = 1;

		private Rigidbody2D _rb2D;
		private InputReader _inputReader;

		private bool _isJumping = false;
		private Vector2 _direction = Vector2.zero;
		private float _jumpRate = 0.5f;
		private float _jumpTimer = 0;
		private bool _isGrounded = false;

		public float AccelerationForce => _acceleration * _rb2D.mass;

		private void Awake()
		{
			_rb2D = GetComponent<Rigidbody2D>();
			_inputReader = GetComponent<InputReader>();
		}

		private void Update()
		{
			_direction = _inputReader.Movement;

			bool shouldJump = _inputReader.Jump;
			if (!_isJumping && shouldJump)
			{
				_isJumping = true;
			}

			UpdateJumpTimer(Time.deltaTime);
		}

		private void UpdateJumpTimer(float deltaTime)
		{
			if (_jumpTimer > 0)
			{
				_jumpTimer -= deltaTime;
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

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
			{
				_isGrounded = true;
			}
		}

		private void OnCollisionExit2D(Collision2D collision)
		{
			if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
			{
				_isGrounded = false;
			}
		}
		#endregion

		#region Internal functionality

		private void Jump()
		{
			if (_jumpTimer > 0)
			{
				// Jump on cooldown, can't jump again just yet.
				return;
			}

			Debug.Log("Jumping");
			if (_isGrounded)
			{
				_rb2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
				_jumpTimer = _jumpRate;
			}
		}

		private void Move(Vector2 direction)
		{
			_rb2D.AddForce(direction * AccelerationForce, ForceMode2D.Force);
			float xSpeed = Mathf.Clamp(_rb2D.velocity.x, -_speed, _speed);
			_rb2D.velocity = new Vector2(xSpeed, _rb2D.velocity.y);
		}
		#endregion
	}
}