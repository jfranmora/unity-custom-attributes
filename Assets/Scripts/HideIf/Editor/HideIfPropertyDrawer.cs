using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(HideIfAttribute))]
public class HideIfPropertyDrawer : PropertyDrawer
{
	public HideIfAttribute TargetAttribute => attribute as HideIfAttribute;

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty(position, label, property);

		try
		{
			DrawField(position, property);
		}
		catch (Exception e)
		{
			DrawFieldWithError(position, property, e.Message);
		}
		
		EditorGUI.EndProperty();
	}

	private void DrawField(Rect position, SerializedProperty property)
	{
		if (CalculateVisibility(property))
		{
			EditorGUI.PropertyField(position, property, true);
		}
	}

	private void DrawFieldWithError(Rect position, SerializedProperty property, string errorMessage)
	{
		var rect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
		EditorGUI.HelpBox(rect, errorMessage, MessageType.Error);

		position.y += EditorGUIUtility.singleLineHeight;
		position.height -= EditorGUIUtility.singleLineHeight;
		EditorGUI.PropertyField(position, property);
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		try
		{
			return CalculateVisibility(property) ? EditorGUI.GetPropertyHeight(property) : 0;
		}
		catch
		{			
			return EditorGUI.GetPropertyHeight(property) + EditorGUIUtility.singleLineHeight;
		}
	}

	private bool CalculateVisibility(SerializedProperty property)
	{
		bool result = GetBoolValue(property);
		return TargetAttribute.Invert ? !result : result;
	}

	private bool GetBoolValue(SerializedProperty property)
	{
		var targetType = property.serializedObject.targetObject.GetType();
		var targetObject = property.serializedObject.targetObject;
		var fieldName = TargetAttribute.FieldName;

		try
		{

			var fieldInfo = targetType.GetField(fieldName);
			if (fieldInfo != null)
			{
				return (bool)fieldInfo.GetValue(targetObject);
			}

			var propertyInfo = targetType.GetProperty(fieldName);
			if (propertyInfo != null)
			{
				return (bool)propertyInfo.GetValue(targetObject);
			}

			var methodInfo = targetType.GetMethod(fieldName);
			if (methodInfo != null)
			{
				return (bool)methodInfo.Invoke(targetObject, null);
			}
		}
		catch (InvalidCastException e)
		{
			throw new Exception($"[HideIf] {fieldName} is not bool");
		}

		throw new Exception($"[HideIf] There is no field named {fieldName}");
	}
}
