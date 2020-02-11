using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MinValueAttribute))]
public class MinValueDrawer : PropertyDrawer
{
	private MinValueAttribute TargetAttribute => attribute as MinValueAttribute;

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		switch (property.propertyType)
		{
			case SerializedPropertyType.Integer:
				property.intValue = Mathf.Max(property.intValue, (int) TargetAttribute.Value);
				break;
			case SerializedPropertyType.Float:
				property.floatValue = Mathf.Max(property.floatValue, TargetAttribute.Value);
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}

		EditorGUI.PropertyField(position, property, label, true);
	}
}