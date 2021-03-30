using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Damageable{
    public class Damageable : MonoBehaviour
    {
        [SerializeField, Range(0, 100f)] private int _life;
        [SerializeField] private DamageableTeam _team;

        private bool _isDead = false;
        public UnityEvent OnDead;
        public void TakeDamage(int damage, DamageableTeam damageSourceTeam){
            if(damageSourceTeam == _team || _isDead)
                return;
            
            _life -= damage;

            if(_life <= 0){
                _isDead = true;
                OnDead.Invoke();
            }
        }
    }
}
public enum DamageableTeam{
    PlayerFriendly,
    Enemy
}
