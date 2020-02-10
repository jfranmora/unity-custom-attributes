using System;
using System.Collections.Generic;
using UnityEditor;

[CustomPropertyDrawer(typeof(DefaultAssetDatabaseInstanceAttribute))]
public class DefaultAssetDatabaseInstanceDrawer : AutoPopulateBaseDrawer<DefaultAssetDatabaseInstanceAttribute>
{
	protected override IEnumerable<UnityEngine.Object> GetElements(SerializedProperty property, Type targetType)
	{
		return AssetDatabaseUtils.GetAssetsFromType(targetType);
	}
}
