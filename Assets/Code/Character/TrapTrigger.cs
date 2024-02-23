using UnityEngine;

namespace Mobiiliesimerkki
{
	public class TrapTrigger : MonoBehaviour
	{
		[SerializeField] private Trap _trap;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player")
			{
				_trap.Trigger();
			}
		}
	}
}