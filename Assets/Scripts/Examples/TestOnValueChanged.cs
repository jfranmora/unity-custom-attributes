using UnityEngine;

public class TestOnValueChanged : MonoBehaviour
{
	[OnValueChanged(nameof(ValueChanged))]
	public float someValue;

	[OnValueChanged(nameof(OnGameObjectChanged))]
	public GameObject target;

	[SerializeField, ReadOnly]
	private Rigidbody rb;

	private void ValueChanged()
	{
		Debug.Log(someValue);
	}

	private void OnGameObjectChanged()
	{
		rb = target != null ? target.GetComponent<Rigidbody>() : null;
	}
}