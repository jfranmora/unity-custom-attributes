using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DefaultGetComponentInChildrenAttribute))]
public class DefaultGetComponentInChildrenDrawer : AutoPopulateBaseDrawer<DefaultGetComponentInChildrenAttribute>
{
	protected override IEnumerable<UnityEngine.Object> GetElements(SerializedProperty property, Type targetType)
	{
		var targetComponent = property.serializedObject.targetObject as Component;
		foreach (var component in targetComponent.GetComponentsInChildren(targetType, TargetAttribute.IncludeInactive))
		{
			yield return component;
		}
	}
}
