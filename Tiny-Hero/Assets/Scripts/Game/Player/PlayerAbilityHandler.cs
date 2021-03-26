using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Ability;

public class PlayerAbilityHandler : MonoBehaviour
{
    [SerializeField] private Dash _dash;

    public Dash Dash{
        get => _dash;
    }

    private Player _player;

    private void Start() {
        _player = GetComponent<Player>();
    }

    private void Update() {
        if(!CheckIfItsOnAllowedState())
            return;
        
        HandleDashInput();
    }

    private void HandleDashInput(){
        if(_player.InputHandler.DashTriggered())
            _dash.TriggerAbility();
    }

    private bool CheckIfItsOnAllowedState(){
        return 
        _player.StateMachine.CurrentState == _player.IdleState ||
        _player.StateMachine.CurrentState == _player.JumpState ||
        _player.StateMachine.CurrentState == _player.MovingState; 
    }
}
