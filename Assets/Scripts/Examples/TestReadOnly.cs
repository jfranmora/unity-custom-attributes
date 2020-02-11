using System;
using UnityEngine;

public class TestReadOnly : MonoBehaviour
{
	[Serializable]
	public struct Data
	{
		[ReadOnly]
		public int a;

		public float b;
	}

	[ReadOnly]
	public int a;

	[ReadOnly]
	public float b;

	[ReadOnly]
	public double c;

	[ReadOnly]
	public char d;

	[ReadOnly]
	public GameObject e;

	[ReadOnly]
	public Data f;

	public Data g;
}