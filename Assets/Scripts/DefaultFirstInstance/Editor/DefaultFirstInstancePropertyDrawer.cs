using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DefaultFirstInstanceAttribute))]
public class DefaultFirstInstancePropertyDrawer : AutoPopulateBasePropertyDrawer
{
	protected override void AutoPopulate(Rect position, SerializedProperty property, GUIContent label)
	{
		var defaultFirstInstanceAttribute = (DefaultFirstInstanceAttribute)attribute;

		Type targetType = defaultFirstInstanceAttribute.TargetType;
		if (targetType == null)
		{
			targetType = ReflectionUtils.GetTypeFromSerializedObject(property);
		}

		var targetObject = AssetDatabaseUtils.GetAssetsFromType(targetType).FirstOrDefault();
		if (targetObject != null)
		{
			property.objectReferenceValue = targetObject;
			property.serializedObject.ApplyModifiedPropertiesWithoutUndo();
		}
	}
}
