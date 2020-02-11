using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

[CustomPropertyDrawer(typeof(DefaultGetComponentInParentAttribute))]
[CanEditMultipleObjects]
public class DefaultGetComponentInParentDrawer : AutoPopulateBaseDrawer<DefaultGetComponentInParentAttribute>
{
	protected override IEnumerable<Object> GetElements(SerializedProperty property, Type targetType)
	{
		var targetComponent = property.serializedObject.targetObject as Component;
		foreach (var component in targetComponent.GetComponentsInParent(targetType, TargetAttribute.IncludeInactive))
		{
			yield return component;
		}
	}
}