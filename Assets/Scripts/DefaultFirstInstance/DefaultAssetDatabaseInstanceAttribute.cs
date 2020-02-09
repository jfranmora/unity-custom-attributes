using System;
using UnityEngine;

public class DefaultAssetDatabaseInstanceAttribute : PropertyAttribute
{
	public Type TargetType { get; private set; } = null;

	public DefaultAssetDatabaseInstanceAttribute()
	{
	}

	public DefaultAssetDatabaseInstanceAttribute(Type targetType)
	{
		TargetType = targetType;
	}
}
