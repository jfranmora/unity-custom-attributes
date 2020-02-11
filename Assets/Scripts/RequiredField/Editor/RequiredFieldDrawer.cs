using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(RequiredFieldAttribute))]
[CanEditMultipleObjects]
public class RequiredFieldDrawer : PropertyDrawer
{
	private readonly Color WrongColor = new Color(239 / 255f, 117 / 255f, 100 / 255f);

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty(position, label, property);

		var lastBackgroundColor = GUI.backgroundColor;
		if (property.objectReferenceValue == null)
		{
			GUI.backgroundColor = WrongColor;
		}

		EditorGUI.PropertyField(position, property, label, true);
		GUI.backgroundColor = lastBackgroundColor;

		EditorGUI.EndProperty();
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return EditorGUI.GetPropertyHeight(property);
	}
}