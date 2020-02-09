using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public abstract class AutoPopulateBasePropertyDrawer<AttributeType> : PropertyDrawer where AttributeType : AutoPopulateBaseAttribute
{
	protected AttributeType TargetAttribute => attribute as AttributeType;

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty(position, label, property);

		EditorGUI.PropertyField(position, property);
		if (property.objectReferenceValue == null)
		{
			PopulateSerializedProperty(property);
		}

		EditorGUI.EndProperty();
	}

	private void PopulateSerializedProperty(SerializedProperty property)
	{
		Type targetType = TargetAttribute.TargetType;
		if (targetType == null)
		{
			targetType = fieldInfo.FieldType;
		}

		var targetObject = GetElements(property, targetType).FirstOrDefault();
		if (targetObject != null)
		{
			property.objectReferenceValue = targetObject as UnityEngine.Object;
			property.serializedObject.ApplyModifiedPropertiesWithoutUndo();
		}
	}

	protected abstract IEnumerable<UnityEngine.Object> GetElements(SerializedProperty property, Type targetType);
}
