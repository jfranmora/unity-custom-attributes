using UnityEngine;

public class HideIfAttribute : PropertyAttribute
{
	public string MemberName { get; private set; }

	public bool Invert { get; private set; }

	public HideIfAttribute(string fieldName) : this(fieldName, false)
	{

	}

	public HideIfAttribute(string fieldName, bool invert)
	{
		MemberName = fieldName;
		Invert = invert;
	}
}
