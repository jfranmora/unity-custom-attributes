using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(OnValueChangedAttribute))]
public class OnValueChangedDrawer : PropertyDrawer
{
	private OnValueChangedAttribute TargetAttribute => (OnValueChangedAttribute) attribute;

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty(position, label, property);

		EditorGUI.BeginChangeCheck();
		EditorGUI.PropertyField(position, property, label, true);
		if (EditorGUI.EndChangeCheck())
		{
			property.serializedObject.ApplyModifiedProperties();
			OnValueChanged(property);
		}

		EditorGUI.EndProperty();
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return EditorGUI.GetPropertyHeight(property, true);
	}

	private void OnValueChanged(SerializedProperty property)
	{
		var methodInfo = property.serializedObject.targetObject.GetType().GetMethod(TargetAttribute.CallbackName,
			BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
		if (methodInfo == null || methodInfo.ReturnType != typeof(void) || methodInfo.GetParameters().Length > 0)
		{
			Debug.LogError($"Callback name: {TargetAttribute.CallbackName} not found or is not valid!");
			return;
		}

		methodInfo.Invoke(property.serializedObject.targetObject, null);
	}
}