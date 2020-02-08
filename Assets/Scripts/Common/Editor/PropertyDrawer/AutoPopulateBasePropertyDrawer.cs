using UnityEditor;
using UnityEngine;

public abstract class AutoPopulateBasePropertyDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.PropertyField(position, property);

		if (property.objectReferenceValue == null)
		{
			AutoPopulate(position, property, label);
		}
	}

	protected abstract void AutoPopulate(Rect position, SerializedProperty property, GUIContent label);
}
