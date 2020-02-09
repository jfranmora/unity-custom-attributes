using UnityEngine;

public class TestDefaultFirstInstance : MonoBehaviour
{
	[DefaultAssetDatabaseInstance]
	public ScriptableObjectData data;

	[DefaultAssetDatabaseInstance]
	public ScriptableObjectData[] dataArray;
}
