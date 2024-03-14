using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobiiliesimerkki
{
	public class Coin : MonoBehaviour
	{
		[SerializeField] private int _score = 1;

		public int Score => _score;
	}
}