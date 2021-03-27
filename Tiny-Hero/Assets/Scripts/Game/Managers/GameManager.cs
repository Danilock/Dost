using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

public class GameManager : Singleton<GameManager>
{
    #region State Machine
    public StateMachine<GameManager> StateMachine;
    public InGameState InGameState = new InGameState();
    public InPauseState InPauseState = new InPauseState();
    #endregion
    public PlayerInputHandler Input;
    public override void Awake()
    {
        if(Instance != null && Instance != this){
            Destroy(this.gameObject);
        }
        else{
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        Input = FindObjectOfType<PlayerInputHandler>();
        StateMachine = new StateMachine<GameManager>(this);
    }

    private void Start() {
        StateMachine.SetState(InGameState);
    }

    private void Update() {
        StateMachine.CurrentState.TickState(this);
    }

    public void EnablePlayerActions(){
        Input.InputActions.Player.Dash.Enable();
        Input.InputActions.Player.Move.Enable();
        Input.InputActions.Player.Jump.Enable();
    }

    public void DisablePlayerActions(){
        Input.InputActions.Player.Move.Disable();
        Input.InputActions.Player.Jump.Disable();
        Input.InputActions.Player.Dash.Disable();
    }
}
