using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Game.Ability{
public abstract class BaseAbility : MonoBehaviour
{
        public string Name;
        [TextArea] public string Description;
        public Image Portrait;
        public float Cooldown;

        [SerializeField] private bool _canUse = true;
        public bool CanUse{ 
            get => _canUse; 
            private set => _canUse = value; 
        }
        [SerializeField] private UnityEvent _onUseAbility;
        public void TriggerAbility(){
            if(!_canUse)
                return;
            
            Ability();
            StartCoroutine(HandleCooldown());
            _onUseAbility.Invoke();
        }

        public abstract void Ability();

        private IEnumerator HandleCooldown(){
            CanUse = false;
            yield return new WaitForSeconds(Cooldown);
            CanUse = true;
        }

        public void EnableAbility(){
            CanUse = true;
            StopCoroutine(HandleCooldown());
        }
    }
}