using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public abstract class AutoPopulateBasePropertyDrawer<AttributeType> : PropertyDrawer
{
	protected AttributeType targetAttribute { get; private set; }

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.PropertyField(position, property);

		if (property.objectReferenceValue == null)
		{
			PopulateSerializedProperty(property);
		}	
	}

	private void PopulateSerializedProperty(SerializedProperty property)
	{
		var defaultFirstInstanceAttribute = (DefaultAssetDatabaseInstanceAttribute)attribute;

		Type targetType = defaultFirstInstanceAttribute.TargetType;
		if (targetType == null)
		{
			targetType = fieldInfo.FieldType;
		}

		var targetObject = GetElements(targetType).FirstOrDefault();
		if (targetObject != null)
		{
			property.objectReferenceValue = targetObject;
			property.serializedObject.ApplyModifiedPropertiesWithoutUndo();
		}
	}

	protected abstract IEnumerable<UnityEngine.Object> GetElements(Type targetType);
}
