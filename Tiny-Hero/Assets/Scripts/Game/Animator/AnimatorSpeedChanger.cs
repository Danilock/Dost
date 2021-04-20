using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSpeedChanger : MonoBehaviour
{
    [SerializeField] private List<AnimatorData> _animatorData;
    void Start()
    {
        InitializeAnimatorData();
    }

    private void InitializeAnimatorData(){
        foreach(AnimatorData data in _animatorData){
            data.Animator.speed = data.Speed;
        }
    }
}
