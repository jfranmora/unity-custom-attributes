﻿using System;
using System.Collections.Generic;
using UnityEditor;

[CustomPropertyDrawer(typeof(DefaultFindObjectAttribute))]
public class DefaultFindObjectAttributeDrawer : AutoPopulateBaseDrawer<DefaultFindObjectAttribute>
{
	protected override IEnumerable<UnityEngine.Object> GetElements(SerializedProperty property, Type targetType)
	{
		foreach (var component in UnityEngine.Object.FindObjectsOfType(targetType))
		{
			yield return component;
		}
	}
}