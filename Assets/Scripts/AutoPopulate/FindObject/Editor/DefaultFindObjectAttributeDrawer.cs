using System;
using System.Collections.Generic;
using UnityEditor;
using Object = UnityEngine.Object;

[CustomPropertyDrawer(typeof(DefaultFindObjectAttribute))]
[CanEditMultipleObjects]
public class DefaultFindObjectAttributeDrawer : AutoPopulateBaseDrawer<DefaultFindObjectAttribute>
{
	protected override IEnumerable<Object> GetElements(SerializedProperty property, Type targetType)
	{
		foreach (var component in Object.FindObjectsOfType(targetType))
		{
			yield return component;
		}
	}
}