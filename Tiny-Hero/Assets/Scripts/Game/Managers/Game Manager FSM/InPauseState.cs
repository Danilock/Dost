using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

public class InPauseState : State<GameManager>
{
    public override void EnterState(GameManager entity)
    {
        Time.timeScale = 0f;

        entity.DisablePlayerActions();
    }

    public override void ExitState(GameManager entity)
    {
        Time.timeScale = 1f;

        entity.EnablePlayerActions();
    }

    public override void TickState(GameManager entity)
    {
        if(entity.Input.InputActions.Player.Pause.triggered){
            entity.StateMachine.SetState(entity.InGameState);
        }
    }
}
