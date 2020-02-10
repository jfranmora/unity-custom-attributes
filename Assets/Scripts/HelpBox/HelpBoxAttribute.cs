using UnityEngine;

public enum HelpBoxMessageType
{
	None,
	Info,
	Warning,
	Error
}

public class HelpBoxAttribute : PropertyAttribute
{
	public string Message { get; private set; }
	public HelpBoxMessageType Style { get; private set; } = HelpBoxMessageType.None;

	public HelpBoxAttribute(string message, HelpBoxMessageType style = HelpBoxMessageType.None)
	{
		Message = message;
		Style = style;
	}
}
