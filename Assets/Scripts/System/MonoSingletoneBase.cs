using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingletoneBase<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;
    public static void SetInstance()
    {
        _instance = FindObjectOfType<T>();
    }
    public static T GetInstance()
    {
        return _instance;
    }
}
