using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

public class InLoadingState : State<GameManager>
{
    public override void EnterState(GameManager entity)
    {
        entity.DisablePlayerActions();
    }

    public override void ExitState(GameManager entity)
    {
        entity.EnablePlayerActions();
    }

    public override void FixedUpdateTick(GameManager entity)
    {
    }

    public override void TickState(GameManager entity)
    {
        
    }
}
