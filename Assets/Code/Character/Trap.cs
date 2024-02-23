using UnityEngine;

namespace Mobiiliesimerkki
{
	public class Trap : MonoBehaviour
	{
		[SerializeField] private Vector2 _launchForce = new Vector2(0, 10);
		private Rigidbody2D _rigidbody;

		public Rigidbody2D Rigidbody => _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		public virtual void Trigger()
		{
			_rigidbody.AddForce(_launchForce, ForceMode2D.Impulse);
		}
	}
}