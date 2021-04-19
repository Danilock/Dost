using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

public class InMenuState : State<GameManager>
{
    public override void EnterState(GameManager entity)
    {
    }

    public override void ExitState(GameManager entity)
    {
        entity.StateMachine.SetState(entity.InLoadingState);
    }
}
