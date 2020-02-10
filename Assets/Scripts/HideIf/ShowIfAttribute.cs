using UnityEngine;

public class ShowIfAttribute : PropertyAttribute
{
	public string MemberName { get; private set; }

	public bool Invert { get; private set; }

	public ShowIfAttribute(string fieldName) : this(fieldName, false)
	{

	}

	public ShowIfAttribute(string fieldName, bool invert)
	{
		MemberName = fieldName;
		Invert = invert;
	}
}
