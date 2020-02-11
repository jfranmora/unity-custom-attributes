using System;

public class DefaultGetComponentInChildrenAttribute : AutoPopulateBaseAttribute
{
	public bool IncludeInactive { get; set; }
	
	public DefaultGetComponentInChildrenAttribute()
	{
	}

	public DefaultGetComponentInChildrenAttribute(Type targetType) : base(targetType)
	{
	}
}