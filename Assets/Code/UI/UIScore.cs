using UnityEngine;
using TMPro;

namespace Mobiiliesimerkki.UI
{
	public class UIScore : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _scoreText;

		private void Awake()
		{
			if (_scoreText == null)
			{
				_scoreText = GetComponent<TextMeshProUGUI>();
			}
		}

		private void Update()
		{
			_scoreText.text = $"Score: {GameManager.Score}";
		}
	}
}