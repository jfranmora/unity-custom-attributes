using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ShowIfAttribute), true)]
public class ShowIfDrawer : PropertyDrawer
{
	public ShowIfAttribute TargetAttribute => attribute as ShowIfAttribute;

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
		var memberName = TargetAttribute.MemberName;

		try
		{
			var memberInfo = targetType.GetMember(memberName, 
				MemberTypes.Field | MemberTypes.Property | MemberTypes.Method,
				BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();

			if (memberInfo != null)
			{
				switch (memberInfo.MemberType)
				{
					case MemberTypes.Field:
						return (bool)((FieldInfo)memberInfo).GetValue(targetObject);
					case MemberTypes.Property:
						return (bool)((PropertyInfo)memberInfo).GetValue(targetObject);
					case MemberTypes.Method:
						return (bool)((MethodInfo)memberInfo).Invoke(targetObject, null);
				}
			}
		}
		catch
		{
			throw new Exception($"[HideIf] {memberName} is not bool");
		}

		throw new Exception($"[HideIf] There is no field named {memberName}");
	}
}
