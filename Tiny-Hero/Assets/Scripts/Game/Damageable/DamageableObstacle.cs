using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Damageable{
    public class DamageableObstacle : MonoBehaviour
    {
        [SerializeField] private int _damage = 100;
        private DamageableTeam _obstacleTeam = DamageableTeam.Enemy;

        private void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.CompareTag("Player")){
                other.gameObject.GetComponent<Damageable>().TakeDamage(_damage, _obstacleTeam);
            }
        }
    }
}