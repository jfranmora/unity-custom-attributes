using System;

public class DefaultGetComponentAttribute : AutoPopulateBaseAttribute
{
	public DefaultGetComponentAttribute()
	{
	}

	public DefaultGetComponentAttribute(Type targetType) : base(targetType)
	{
	}
}