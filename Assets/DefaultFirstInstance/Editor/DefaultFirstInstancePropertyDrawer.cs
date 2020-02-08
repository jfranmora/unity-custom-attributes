using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DefaultFirstInstanceAttribute))]
public class DefaultFirstInstancePropertyDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.PropertyField(position, property);

		if (property.objectReferenceValue == null)
		{
			var defaultFirstInstanceAttribute = (DefaultFirstInstanceAttribute)attribute;

			Type targetType = defaultFirstInstanceAttribute.TargetType;
			if (targetType == null)
			{
				targetType = GetTypeFromSerializedObject(property);
			}

			var targetObject = GetAllAssetsFromDatabase(targetType).FirstOrDefault();
			if (targetObject != null)
			{
				property.objectReferenceValue = targetObject;
				property.serializedObject.ApplyModifiedPropertiesWithoutUndo();
			}
		}
	}

	private Type GetTypeFromSerializedObject(SerializedProperty property)
	{
		Type parentType = property.serializedObject.targetObject.GetType();
		FieldInfo fieldInfo = parentType.GetField(property.propertyPath);
		return fieldInfo.FieldType;
	}

	private IEnumerable<UnityEngine.Object> GetAllAssetsFromDatabase(Type targetType)
	{
		return AssetDatabase.FindAssets($"t:{targetType.Name}")
			.Select(AssetDatabase.GUIDToAssetPath)
			.Select(path => AssetDatabase.LoadAssetAtPath(path, targetType));
	}
}
