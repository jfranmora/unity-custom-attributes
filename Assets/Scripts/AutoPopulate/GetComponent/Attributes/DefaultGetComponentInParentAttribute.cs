using System;

public class DefaultGetComponentInParentAttribute : AutoPopulateBaseAttribute
{
	public GetComponentType Type { get; set; }
	public bool IncludeInactive { get; set; }

	public DefaultGetComponentInParentAttribute()
	{
	}

	public DefaultGetComponentInParentAttribute(Type targetType) : base(targetType)
	{
	}
}