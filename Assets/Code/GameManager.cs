using UnityEngine;

namespace Mobiiliesimerkki
{
	public static class GameManager
	{
		private static int _score = 0;

		public static int Score
		{
			get => _score;
			set
			{
				_score = Mathf.Clamp(value, 0, int.MaxValue);
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
