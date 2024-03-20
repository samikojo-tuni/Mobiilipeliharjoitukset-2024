using UnityEngine;
using TMPro;

namespace Mobiiliesimerkki.UI
{
	public class UIPause : MonoBehaviour
	{
		private TMP_Text _pauseText;

		private void Awake()
		{
			_pauseText = GetComponent<TMP_Text>();
			_pauseText.text = "Pause";
			gameObject.SetActive(false);
		}

		public void SetPause(bool isPaused)
		{
			gameObject.SetActive(isPaused);
		}
	}
}
