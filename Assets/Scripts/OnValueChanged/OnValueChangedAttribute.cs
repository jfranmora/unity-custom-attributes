using UnityEngine;

public class OnValueChangedAttribute : PropertyAttribute
{
	public string CallbackName { get; }

	public OnValueChangedAttribute(string callbackName)
	{
		CallbackName = callbackName;
	}
}