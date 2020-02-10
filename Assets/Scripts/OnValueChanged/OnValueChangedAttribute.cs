using UnityEngine;

public class OnValueChangedAttribute : PropertyAttribute
{
	public string CallbackName { get; private set; }

	public OnValueChangedAttribute(string callbackName)
	{
		CallbackName = callbackName;
	}
}