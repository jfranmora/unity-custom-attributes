using UnityEngine;

public class TestHideIf : MonoBehaviour
{	
	public enum VehicleType
	{
		Car,
		Motorbike
	}

	[System.Serializable]
	public struct TestData
	{
		public int a;
		public float b;
		public GameObject c;
	}

	public bool a0;
	public bool b0;
	public VehicleType Type;

	public bool CarSelected => Type == VehicleType.Car;

	[HideIf(nameof(a0))]
	public float hidden1;

	[HideIf(nameof(SomeMethod))]
	public float hidden3;

	[HideIf(nameof(CarSelected))]
	public TestData hidden2;

	private bool SomeMethod() 
	{
		return b0;
	}
}
