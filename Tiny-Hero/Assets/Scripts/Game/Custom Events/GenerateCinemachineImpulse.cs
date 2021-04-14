using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GenerateCinemachineImpulse : MonoBehaviour
{
    [SerializeField] private CinemachineImpulseSource _impulseSource;

    [ContextMenu("Generate Impulse")]
    public void GenerateImpulse() => _impulseSource.GenerateImpulse(); 
}
