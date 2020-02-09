using System;

public class DefaultGetComponentAttribute : AutoPopulateBaseAttribute
{
	public GetComponentType Type { get; set; }

	public DefaultGetComponentAttribute()
	{
	}

	public DefaultGetComponentAttribute(Type targetType) : base(targetType)
	{
	}
}