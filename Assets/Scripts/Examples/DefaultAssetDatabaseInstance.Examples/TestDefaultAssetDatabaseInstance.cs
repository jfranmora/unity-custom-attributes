using UnityEngine;

public class TestDefaultAssetDatabaseInstance : MonoBehaviour
{
	[DefaultAssetDatabaseInstance]
	public TestDefaultAssetDatabaseInstanceSO data;

	[DefaultAssetDatabaseInstance]
	public TestDefaultAssetDatabaseInstanceSO[] dataArray;
}