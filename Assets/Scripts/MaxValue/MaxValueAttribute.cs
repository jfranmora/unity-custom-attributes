using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxValueAttribute : PropertyAttribute
{
	public float Value { get; }

	public MaxValueAttribute(float value)
	{
		Value = value;
	}
}