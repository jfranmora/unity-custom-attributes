using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

public static class AssetDatabaseUtils
{
	public static IEnumerable<UnityEngine.Object> GetAssetsFromType(Type targetType)
	{
		return AssetDatabase.FindAssets($"t:{targetType.Name}")
			.Select(AssetDatabase.GUIDToAssetPath)
			.Select(path => AssetDatabase.LoadAssetAtPath(path, targetType));
	}
}
