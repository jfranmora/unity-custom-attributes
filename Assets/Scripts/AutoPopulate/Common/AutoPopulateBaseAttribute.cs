using System;
using UnityEngine;

public abstract class AutoPopulateBaseAttribute : PropertyAttribute
{
	public Type TargetType { get; private set; }
	
	public AutoPopulateBaseAttribute()
	{
	}

	public AutoPopulateBaseAttribute(Type targetType)
	{
		TargetType = targetType;
	}
}