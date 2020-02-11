using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(HelpBoxAttribute))]
[CanEditMultipleObjects]
public class HelpBoxAttributeDrawer : DecoratorDrawer
{
	private const float FieldSeparation = 10;

	private HelpBoxAttribute TargetAttribute => (HelpBoxAttribute) attribute;

	public override void OnGUI(Rect position)
	{
		position.height -= FieldSeparation;
		position.y += FieldSeparation / 2f;

		EditorGUI.HelpBox(position, TargetAttribute.Message, ToUnityEditorMessageType(TargetAttribute.Style));
	}

	public override float GetHeight()
	{
		var style = GUI.skin != null ? GUI.skin.GetStyle("helpbox") : null;
		if (style == null) return base.GetHeight();

		return style.CalcHeight(new GUIContent(TargetAttribute.Message), EditorGUIUtility.currentViewWidth) + 5 +
		       FieldSeparation;
	}

	private MessageType ToUnityEditorMessageType(HelpBoxMessageType style)
	{
		switch (style)
		{
			case HelpBoxMessageType.None: return MessageType.None;
			case HelpBoxMessageType.Info: return MessageType.Info;
			case HelpBoxMessageType.Warning: return MessageType.Warning;
			case HelpBoxMessageType.Error: return MessageType.Error;
		}

		return MessageType.None;
	}
}