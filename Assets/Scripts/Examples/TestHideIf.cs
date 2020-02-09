using UnityEngine;

public class TestHideIf : MonoBehaviour
{	
	[System.Serializable]
	public struct TestData
	{
		public int a;
		public float b;
		public GameObject c;
	}

	public bool a0;

	public bool b0;

	[HideIf(nameof(a0))]
	public float value;

	[HideIf(nameof(b0))]
	public float value2;

	[HideIf(nameof(b0))]
	public TestData data;
}
