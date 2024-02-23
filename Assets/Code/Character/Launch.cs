using UnityEngine;

namespace Mobiiliesimerkki
{
	public class Launch : MonoBehaviour
	{
		[SerializeField, Tooltip("m/s^2")] private float _maxAcceleration = 10f;
		[SerializeField] private float _accelerationIncrement = 1;
		[SerializeField] private Vector2 _direction = Vector2.up;

		private Inputs _inputs;
		private Rigidbody2D _rigidbody;
		private bool _isLaunching = false;
		private float _acceleration = 0;

		// Force = mass * acceleration (N = kg * m/s^2)
		public float LaunchForce => _acceleration * _rigidbody.mass;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			_inputs = new Inputs();
		}

		private void OnEnable()
		{
			_inputs.Game.Enable();
		}

		private void OnDisable()
		{
			_inputs.Game.Disable();
		}

		private void Update()
		{
			if (_inputs.Game.Launch.WasPerformedThisFrame())
			{
				_isLaunching = true;
			}

			if (_isLaunching)
			{
				_acceleration = Mathf.Clamp(_acceleration + _accelerationIncrement * Time.deltaTime, 0, _maxAcceleration);
			}

			if (_inputs.Game.Launch.WasReleasedThisFrame())
			{
				_isLaunching = false;
			}
		}

		private void FixedUpdate()
		{
			if (!_isLaunching && _acceleration > 0)
			{
				_rigidbody.AddForce(_direction.normalized * LaunchForce, ForceMode2D.Impulse);
				_acceleration = 0;
			}
		}
	}
}