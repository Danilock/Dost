using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

public class PlayerJumpState : State<Player>
{
    private bool _canDoubleJump = true; 
    public override void EnterState(Player entity)
    {
        entity.AnimationHandler.TriggerJumpAnimation();
        _canDoubleJump = true;
    }

    public override void ExitState(Player entity)
    {
        _canDoubleJump = true;
    }

    public override void TickState(Player entity)
    {
        entity.CharacterController.Move(
            entity.InputHandler.Move.x,
            false,
            false
        );

        if(entity.InputHandler.JumpTriggered() && _canDoubleJump){
            entity.CharacterController.Jump();
            _canDoubleJump = false;
        }
    }

    public override void FixedUpdateTick(Player entity)
    {
        if(entity.CharacterController.IsTotallyGrounded())
        {
            entity.StateMachine.SetState(entity.IdleState);
        }
    }
}
