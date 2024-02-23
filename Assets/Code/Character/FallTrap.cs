namespace Mobiiliesimerkki
{
	public class FallTrap : Trap
	{
		private void Start()
		{
			Rigidbody.gravityScale = 0;
		}

		public override void Trigger()
		{
			Rigidbody.gravityScale = 1;
		}
	}
}