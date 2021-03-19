using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class ExtensionMethod
{
    public static void Log(this object value)
    {
#if Unity_Editor
        Debug.Log(value);
#endif
    }
}