using System;
using UnityEngine;

public class DefaultFirstInstanceAttribute : PropertyAttribute
{
	public Type TargetType { get; private set; } = null;

	public DefaultFirstInstanceAttribute()
	{
	}

	public DefaultFirstInstanceAttribute(Type targetType)
	{
		TargetType = targetType;
	}
}
