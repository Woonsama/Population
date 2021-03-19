using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    private void Awake()
    {
        OnAwake();
    }

    private void OnAwake()
    {
        StartCoroutine(OnAwakeCoroutine());
    }

    protected virtual IEnumerator OnAwakeCoroutine()
    {
        yield break;
    }
}