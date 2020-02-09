using UnityEngine;

public class TestRequiredField : MonoBehaviour
{
	[System.Serializable]
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
