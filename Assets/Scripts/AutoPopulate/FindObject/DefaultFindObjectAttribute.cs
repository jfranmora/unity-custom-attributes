using System;

public class DefaultFindObjectAttribute : AutoPopulateBaseAttribute
{
	public DefaultFindObjectAttribute()
	{
	}

	public DefaultFindObjectAttribute(Type targetType) : base(targetType)
	{
	}
}