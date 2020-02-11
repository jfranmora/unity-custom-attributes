using System;
using System.Collections.Generic;
using UnityEditor;
using Object = UnityEngine.Object;

[CustomPropertyDrawer(typeof(DefaultAssetDatabaseInstanceAttribute))]
[CanEditMultipleObjects]
public class DefaultAssetDatabaseInstanceDrawer : AutoPopulateBaseDrawer<DefaultAssetDatabaseInstanceAttribute>
{
	protected override IEnumerable<Object> GetElements(SerializedProperty property, Type targetType)
	{
		return AssetDatabaseUtils.GetAssetsFromType(targetType);
	}
}