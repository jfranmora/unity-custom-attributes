using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

[CustomPropertyDrawer(typeof(DefaultGetComponentAttribute))]
[CanEditMultipleObjects]
public class DefaultGetComponentDrawer : AutoPopulateBaseDrawer<DefaultGetComponentAttribute>
{
	protected override IEnumerable<Object> GetElements(SerializedProperty property, Type targetType)
	{
		var targetComponent = property.serializedObject.targetObject as Component;
		foreach (var component in targetComponent.GetComponents(targetType))
		{
			yield return component;
		}
	}
}