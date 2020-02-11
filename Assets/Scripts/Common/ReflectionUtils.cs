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

	public static T GetValueFromMemberInfo<T>(MemberInfo memberInfo, object targetObject)
	{
		switch (memberInfo.MemberType)
		{
			case MemberTypes.Field:
				return (T) ((FieldInfo) memberInfo).GetValue(targetObject);
			case MemberTypes.Property:
				return (T) ((PropertyInfo) memberInfo).GetValue(targetObject);
			case MemberTypes.Method:
				return (T) ((MethodInfo) memberInfo).Invoke(targetObject, null);
		}

		throw new ArgumentException($"{memberInfo} value is not from type {typeof(T).Name}");
	}
}