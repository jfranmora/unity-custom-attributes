using UnityEngine;

public class ShowIfAttribute : PropertyAttribute
{
	public string MemberName { get; }

	public bool Invert { get; }

	public ShowIfAttribute(string fieldName, bool invert = false)
	{
		MemberName = fieldName;
		Invert = invert;
	}
}