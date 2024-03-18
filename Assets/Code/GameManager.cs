using UnityEngine;

namespace Mobiiliesimerkki
{
	public static class GameManager
	{
		public static event System.Action<int> ScoreChanged;
		private static int _score = 0;

		public static int Score
		{
			get => _score;
			set
			{
				_score = Mathf.Clamp(value, 0, int.MaxValue);

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
			Reset();
		}

		private static void Reset()
		{
			Score = 0;
		}
	}
}
