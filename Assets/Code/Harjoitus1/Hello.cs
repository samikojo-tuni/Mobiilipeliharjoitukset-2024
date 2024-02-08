using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedGooGame
{
	public class Hello : MonoBehaviour
	{
		private int current = 0;
		private int next = 1;

		// Start is called before the first frame update
		void Start()
		{
			Debug.Log("Hello, World!");
		}

		// Update is called once per frame
		void Update()
		{
			if (current < 1000)
			{
				Debug.Log(current);
				int temp = next;
				next = current + next;
				current = temp;
			}
		}
	}
}