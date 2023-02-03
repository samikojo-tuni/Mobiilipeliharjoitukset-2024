using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	[SerializeField]
	private int minX = 0;

	[SerializeField]
	private int maxX = 10;

	private int direction = 1;

	// Update is called once per frame
	void Update()
	{
		if (direction > 0 && transform.position.x > maxX)
		{
			direction = -1;
		}
		else if (direction < 0 && transform.position.x < minX)
		{
			direction = 1;
		}

		Vector3 movement = Vector3.right * direction * Time.deltaTime;
		transform.Translate(movement);
	}
}
