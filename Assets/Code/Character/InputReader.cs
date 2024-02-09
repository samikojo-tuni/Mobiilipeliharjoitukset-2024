using UnityEngine;

namespace Mobiiliesimerkki
{
	public class InputReader : MonoBehaviour
	{
		private Inputs _inputs = null;

		public Vector2 Movement
		{
			get;
			private set;
		}

		public bool Jump
		{
			get;
			private set;
		}

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
			Movement = _inputs.Game.Move.ReadValue<Vector2>();
			Jump = _inputs.Game.Jump.IsPressed();
		}
	}
}