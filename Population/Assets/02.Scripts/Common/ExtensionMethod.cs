using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class ExtensionMethod
{
    public static void Log(this object value)
    {
#if UNITY_EDITOR
        Debug.Log(value);
#endif
    }
}