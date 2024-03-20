using Mobiiliesimerkki.UI;
using UnityEngine;

namespace Mobiiliesimerkki
{
	public class Pause : MonoBehaviour
	{
		private Inputs _inputs;
		[SerializeField] private UIPause _uiPause;

		private void Awake()
		{
			_inputs = new Inputs();
		}

		private void OnEnable()
		{
			_inputs.Game.Enable();
		}

		private void OnDisable()
		{
			_inputs.Game.Disable();
		}

		private void Update()
		{
			if (_inputs.Game.Pause.WasPerformedThisFrame())
			{
				if (Mathf.Approximately(Time.timeScale, 0))
				{
					Time.timeScale = 1;
					_uiPause.SetPause(false);
				}
				else
				{
					Time.timeScale = 0;
					_uiPause.SetPause(true);
				}
			}
		}
	}
}