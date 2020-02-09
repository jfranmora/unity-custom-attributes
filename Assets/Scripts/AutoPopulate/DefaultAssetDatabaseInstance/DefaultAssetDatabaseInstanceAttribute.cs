using System;

public class DefaultAssetDatabaseInstanceAttribute : AutoPopulateBaseAttribute
{
	public DefaultAssetDatabaseInstanceAttribute()
	{
	}

	public DefaultAssetDatabaseInstanceAttribute(Type targetType) : base(targetType)
	{
	}
}