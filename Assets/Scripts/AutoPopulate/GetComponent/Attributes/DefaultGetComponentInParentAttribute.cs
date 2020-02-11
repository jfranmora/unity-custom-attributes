using System;

public class DefaultGetComponentInParentAttribute : AutoPopulateBaseAttribute
{
	public bool IncludeInactive { get; set; }

	public DefaultGetComponentInParentAttribute()
	{
	}

	public DefaultGetComponentInParentAttribute(Type targetType) : base(targetType)
	{
	}
}