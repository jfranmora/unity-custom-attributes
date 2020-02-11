using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MaxValueAttribute))]
public class MaxValueDrawer : PropertyDrawer
{
	private MaxValueAttribute TargetAttribute => attribute as MaxValueAttribute;

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		switch (property.propertyType)
		{
			case SerializedPropertyType.Integer:
				property.intValue = Mathf.Min(property.intValue, (int) TargetAttribute.Value);
				break;
			case SerializedPropertyType.Float:
				property.floatValue = Mathf.Min(property.floatValue, TargetAttribute.Value);
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}

		EditorGUI.PropertyField(position, property, label, true);
	}
}