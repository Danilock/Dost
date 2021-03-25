using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Damageable{
    public class Damageable : MonoBehaviour
    {
        [SerializeField, Range(0, 100f)] private int _life;
        [SerializeField] private DamageableTeam _team;
        public UnityEvent OnDead;
        public void TakeDamage(int damage, DamageableTeam damageSourceTeam){
            if(damageSourceTeam == _team)
                return;
            
            _life -= damage;

            if(_life <= 0){
                OnDead.Invoke();
            }
        }
    }
}
public enum DamageableTeam{
    PlayerFriendly,
    Enemy
}
