using System;

public class DefaultGetComponentInChildrenAttribute : AutoPopulateBaseAttribute
{
	public GetComponentType Type { get; set; }
	public bool IncludeInactive { get; set; }

	public DefaultGetComponentInChildrenAttribute()
	{
	}

	public DefaultGetComponentInChildrenAttribute(Type targetType) : base(targetType)
	{
	}
}