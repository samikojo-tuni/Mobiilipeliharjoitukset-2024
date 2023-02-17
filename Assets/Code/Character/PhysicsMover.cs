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

		[SerializeField]
		private float jumpForce = 1;

		private Rigidbody2D rb2D;
		private InputReader inputReader;

		private bool isJumping = false;
		private Vector2 direction = Vector2.zero;
		private float jumpRate = 0.5f;
		private float jumpTimer = 0;
		private bool isGrounded = false;

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

			UpdateJumpTimer(Time.deltaTime);
		}

		private void UpdateJumpTimer(float deltaTime)
		{
			if (jumpTimer > 0)
			{
				jumpTimer -= deltaTime;
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

		private void OnCollisionEnter2D(Collision2D collision)
		{
 			this.isGrounded = collision.gameObject.layer == LayerMask.NameToLayer("Ground");
		}

		private void OnCollisionExit2D(Collision2D collision)
		{
			if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
			{
				this.isGrounded = false;
			}
		}

		private void Jump()
		{
			if (jumpTimer > 0)
			{
				// Jump on cooldown, can't jump again just yet.
				return;
			}

			Debug.Log("Jumping");
			if (this.isGrounded)
			{
				rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
				jumpTimer = jumpRate;
			}
		}

		private void Move(Vector2 direction)
		{
			Vector2 velocity = rb2D.velocity;
			velocity.x = direction.x * speed;
			rb2D.velocity = velocity;
		}
	}
}