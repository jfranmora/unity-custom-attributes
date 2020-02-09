using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DefaultGetComponentAttribute))]
public class DefaultGetComponentPropertyDrawer : AutoPopulateBasePropertyDrawer<DefaultGetComponentAttribute>
{
	protected override IEnumerable<UnityEngine.Object> GetElements(SerializedProperty property, Type targetType)
	{
		var targetComponent = property.serializedObject.targetObject as Component;
		foreach (var component in targetComponent.GetComponents(targetType))
		{
			yield return component;
		}
	}
}
