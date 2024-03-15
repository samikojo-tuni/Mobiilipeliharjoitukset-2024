using UnityEngine;

namespace Mobiiliesimerkki
{
	public class CharacterControl : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D otherCollider)
		{
			if (otherCollider.gameObject.TryGetComponent<Coin>(out Coin coin))
			{
				GameManager.Score += coin.Score;
				Destroy(otherCollider.gameObject);
			}
		}
	}
}