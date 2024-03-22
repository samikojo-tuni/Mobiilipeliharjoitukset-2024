using UnityEngine;
using UnityEngine.UI;

namespace Mobiiliesimerkki.UI
{
	public class UIResetScore : MonoBehaviour
	{
		private Button _resetButton;

		private void Awake()
		{
			_resetButton = GetComponent<Button>();
		}

		private void OnEnable()
		{
			_resetButton.onClick.AddListener(OnReset);
		}

		private void OnDisable()
		{
			_resetButton.onClick.RemoveListener(OnReset);
		}

		public void OnReset()
		{
			GameManager.Reset();
		}
	}
}
