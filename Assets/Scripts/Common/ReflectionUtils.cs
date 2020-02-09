using System;
using System.Reflection;
using UnityEditor;

public static class ReflectionUtils
{
	public static Type GetTypeFromSerializedObject(SerializedProperty property)
	{
		Type parentType = property.serializedObject.targetObject.GetType();
		FieldInfo fieldInfo = parentType.GetField(property.name);
		return fieldInfo.FieldType;
	}
}
