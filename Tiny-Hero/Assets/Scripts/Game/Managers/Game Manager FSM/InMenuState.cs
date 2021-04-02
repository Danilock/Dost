using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

public class InMenuState : State<GameManager>
{
    public override void EnterState(GameManager entity)
    {
        entity.Input.Player.Disable();
        entity.Input.UI.Enable();
    }

    public override void ExitState(GameManager entity)
    {
        entity.Input.UI.Disable();
        entity.Input.Player.Enable();

        entity.StateMachine.SetState(entity.InLoadingState);
    }
}
