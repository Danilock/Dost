using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

public class PlayerMovingState : State<Player>
{
    public override void EnterState(Player entity)
    {
        entity.AnimationHandler.TriggerWalkAnimation();
    }

    public override void ExitState(Player entity)
    {
        
    }

    public override void TickState(Player entity)
    {
        entity.CharacterController.Move(
            entity.InputHandler.Move.x,
            false,
            false
        );

        if(entity.InputHandler.JumpTriggered() && entity.CharacterController.IsTotallyGrounded()){
            entity.CharacterController.Jump();
            entity.StateMachine.SetState(entity.JumpState);
        }
        else if(entity.InputHandler.Move.magnitude < .1f){
            entity.StateMachine.SetState(entity.IdleState);
        }
        else if(!entity.CharacterController.IsTotallyGrounded()){
            entity.StateMachine.SetState(entity.JumpState);
        }
    }
}
