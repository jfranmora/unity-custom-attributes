using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleReadOnly : MonoBehaviour
{
    public int a;
    [ReadOnly] public float b;
    public string c;
}
