using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

public class InGameState : State<GameManager>
{
    public override void EnterState(GameManager entity)
    {
        
    }

    public override void ExitState(GameManager entity)
    {
        
    }

    public override void TickState(GameManager entity)
    {
        if(entity.Input.Player.Pause.triggered){
            entity.StateMachine.SetState(entity.InPauseState);
        }
    }
}
