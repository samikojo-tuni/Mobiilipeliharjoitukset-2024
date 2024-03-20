using UnityEngine;

namespace Mobiiliesimerkki
{
	public static class GameManager
	{
		public static event System.Action<int> ScoreChanged;
		private static int _score = 0;
		private const string ScoreKey = "Score";

		public static int Score
		{
			get => _score;
			set
			{
				_score = Mathf.Clamp(value, 0, int.MaxValue);

				PlayerPrefs.SetInt(ScoreKey, _score);

				if (ScoreChanged != null)
				{
					ScoreChanged(_score);
				}
			}
		}

		// Staattinen rakentaja. Kutsutaan automaattisesti ennen,
		// kun luokkaa (tai staattista tyyppiä) käytetään ensimmäistä kertaa.
		// Staattinen rakentaja suoritetaan maksimissaan kerran pelin suorituksen aikana.
		static GameManager()
		{
			Score = PlayerPrefs.GetInt(ScoreKey, 0);
			// Reset();
		}

		public static void Reset()
		{
			Score = 0;
			PlayerPrefs.DeleteKey(ScoreKey);
		}
	}
}
