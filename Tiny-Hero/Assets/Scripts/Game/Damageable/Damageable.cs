using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField, Range(0, 10f)] private float _life;
    public UnityEvent OnDead;
    public void TakeDamage(float Damage){
        _life -= Damage;

        if(_life <= 0){
            OnDead.Invoke();
        }
    }
}
