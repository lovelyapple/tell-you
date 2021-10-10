using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSingletoneBase<T> where T : new()
{
    protected static T _instance;
    public static T GetInstance()
    {
        return _instance;
    }
    public static void SetInstance(T newInstance)
    {
        _instance = newInstance;
    }
}
