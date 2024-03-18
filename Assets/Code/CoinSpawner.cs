using UnityEngine;

namespace Mobiiliesimerkki
{
	public class CoinSpawner : MonoBehaviour
	{
		[SerializeField] private Coin _coinPrefab;
		[SerializeField] private float _spawnInterval = 1f;
		[SerializeField] private Vector2 _areaExtents = new Vector2(5, 5);
		[SerializeField] private int _maxCoins = 5;

		private float _spawnTimer = 0;
		private int _coinCount = 0;

		private void Start()
		{
			SetTimer();
		}

		private void Update()
		{
			if (_spawnTimer > 0)
			{
				_spawnTimer -= Time.deltaTime;
				if (_spawnTimer <= 0)
				{
					SpawnCoin();
					SetTimer();
				}
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireCube(transform.position, new Vector3(_areaExtents.x * 2, _areaExtents.y * 2, 0));
		}

		private Coin SpawnCoin()
		{
			float x = transform.position.x + Random.Range(-_areaExtents.x, _areaExtents.x);
			float y = transform.position.y + Random.Range(-_areaExtents.y, _areaExtents.y);

			Coin coin = Instantiate(_coinPrefab, new Vector3(x, y, 0), Quaternion.identity);
			_coinCount++;

			return coin;
		}

		private bool SetTimer()
		{
			if (_coinCount >= _maxCoins)
			{
				return false;
			}

			_spawnTimer = _spawnInterval;
			return true;
		}
	}
}