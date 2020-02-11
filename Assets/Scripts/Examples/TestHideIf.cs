using System;
using UnityEngine;

public class TestHideIf : MonoBehaviour
{
	public enum VehicleType
	{
		Car,
		Motorbike
	}

	[Serializable]
	public struct TestData
	{
		public int a;
		public float b;
		public GameObject c;
	}

	public bool a0;
	public bool b0;
	public VehicleType Type;

	[HideIf(nameof(a0))]
	public float data1;

	[HideIf(nameof(SomeMethod))]
	public float data2;

	[HideIf(nameof(CarSelected))]
	public TestData data3;

	public bool CarSelected => Type == VehicleType.Car;

	private bool SomeMethod()
	{
		return b0;
	}
}