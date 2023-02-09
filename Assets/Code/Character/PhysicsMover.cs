using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedGooGame
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PhysicsMover : MonoBehaviour
	{
		[SerializeField]
		private float speed = 1;

		private Rigidbody2D rb2D;
		private InputReader inputReader;

		private bool isJumping = false;
		private Vector2 direction = Vector2.zero;

		private void Awake()
		{
			rb2D = GetComponent<Rigidbody2D>();
			inputReader = GetComponent<InputReader>();
		}

		private void Update()
		{
			direction = inputReader.GetMovement();

			bool isJumping = inputReader.IsJumping();
			if (!this.isJumping && isJumping)
			{
				this.isJumping = true;
			}
		}

		private void FixedUpdate()
		{
			Move(direction);
			if (this.isJumping )
			{
				Jump();

				// Jump input consumed
				this.isJumping = false;
			}
		}

		private void Jump()
		{
			Debug.Log("Jumping");
		}

		private void Move(Vector2 direction)
		{
			Vector2 velocity = rb2D.velocity;
			velocity.x = direction.x * speed;
			rb2D.velocity = velocity;
		}
	}
}