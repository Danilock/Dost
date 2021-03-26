using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour
{
    protected static T _instance; 
    public static T Instance{
        get{
            return _instance;
        }
        protected set => _instance = value;
    }

    public abstract void Awake();
}
