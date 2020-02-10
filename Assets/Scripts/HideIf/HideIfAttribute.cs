public class HideIfAttribute : ShowIfAttribute
{
	public HideIfAttribute(string fieldName) : base(fieldName, true)
	{
	}

	public HideIfAttribute(string fieldName, bool invert) : base(fieldName, !invert)
	{
	}
}
