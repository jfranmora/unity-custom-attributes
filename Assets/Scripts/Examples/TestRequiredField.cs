using System;
using UnityEngine;

public class TestRequiredField : MonoBehaviour
{
	[Serializable]
	public struct Data
	{
		public float a;
		public char c;

		[RequiredField]
		public GameObject d;
	}

	[RequiredField]
	public GameObject go;

	public Data data;
}