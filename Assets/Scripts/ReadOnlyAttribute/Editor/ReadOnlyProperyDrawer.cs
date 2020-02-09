using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyProperyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        bool enabledState = GUI.enabled;
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label);
        GUI.enabled = enabledState;
    }
}
