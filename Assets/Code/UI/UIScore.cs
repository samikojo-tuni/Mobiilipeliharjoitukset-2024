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

			// OnScoreChanged(GameManager.Score);
		}

		private void Update()
		{
			_scoreText.text = $"Score: {GameManager.Score}";
		}

		// private void OnEnable()
		// {
		// 	GameManager.ScoreChanged += OnScoreChanged;
		// }

		// private void OnDisable()
		// {
		// 	GameManager.ScoreChanged -= OnScoreChanged;
		// }

		// private void OnScoreChanged(int currentScore)
		// {
		// 	_scoreText.text = $"Score: {currentScore}";
		// }
	}
}