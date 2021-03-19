using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class SingletonMonoBase<T> :MonoBehaviour where T :MonoBehaviour
{
    private static T instance = null;
    private static object _synobj = new object();
    private static bool appIsClosing = false;

    public static T Instance
    {
        get
        {
            if (appIsClosing) return null;

            lock (_synobj)
            {
                if(instance == null)
                {
                    T[] objs = FindObjectsOfType<T>();

                    if (objs.Length > 0) instance = objs[0];
                    if (objs.Length > 1) Debug.LogError("There is more than one" + typeof(T).Name + "in the scene.");

                    string goName = typeof(T).ToString();
                    GameObject go = GameObject.Find(goName);

                    if (go == null) go = new GameObject(goName);
                    instance = go.AddComponent<T>();
                }
                return instance;
            }
        }
    }


    private void Awake()
    {
        StartCoroutine(OnAwakeCoroutine());
    }
    protected virtual IEnumerator OnAwakeCoroutine()
    {
        yield return null;
    }
}
