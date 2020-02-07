using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleReadOnlyAttribute : MonoBehaviour
{
    public int a;
    [ReadOnly] public float b;
    public string c;
}
