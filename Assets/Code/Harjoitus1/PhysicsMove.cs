using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedGooGame
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PhysicsMove : MonoBehaviour
	{
		[SerializeField]
		private Vector2 target;

		[SerializeField]
		private float offset;

		private Rigidbody2D rb;
		private bool targetReached = false;

		// Start is called before the first frame update
		void Start()
		{
			rb = GetComponent<Rigidbody2D>();
		}

		void FixedUpdate()
		{
			if (targetReached)
			{
				return;
			}

			Vector2 movement = (target - rb.position);
			if (movement.magnitude > offset)
			{
				movement = movement.normalized;
				movement *= Time.fixedDeltaTime;

				rb.MovePosition(rb.position + movement);
			}
			else
			{
				targetReached = true;
			}
		}
	}
}