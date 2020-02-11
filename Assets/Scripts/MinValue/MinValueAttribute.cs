using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinValueAttribute : PropertyAttribute
{
	public float Value { get; }

	public MinValueAttribute(float value)
	{
		Value = value;
	}
}