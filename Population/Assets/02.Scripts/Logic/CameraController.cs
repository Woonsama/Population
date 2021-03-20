using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject target;

    private void Update()
    {
        Follow();
    }

    public void SetTarget(GameObject obj)
    {
        target = obj;
    }

    public void DetachTarget()
    {
        target = null;
    }

    private void Follow()
    {
        if(target != null)
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        }
    }
}