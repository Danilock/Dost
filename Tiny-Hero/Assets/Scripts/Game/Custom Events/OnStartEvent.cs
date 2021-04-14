using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnStartEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _OnStart;

    private void Start() {
        _OnStart.Invoke();
    }
}
