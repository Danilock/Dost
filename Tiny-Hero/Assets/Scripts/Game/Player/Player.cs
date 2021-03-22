using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

public class Player : MonoBehaviour
{
    #region PlayerFSM
    public PlayerIdleState IdleState = new PlayerIdleState(); 
    public PlayerMovingState MovingState = new PlayerMovingState();
    public PlayerJumpState JumpState = new PlayerJumpState();
    #endregion

    public CharacterController2D CharacterController { get; private set; }

    public StateMachine<Player> StateMachine;

    public PlayerInputHandler InputHandler { get; private set; }
    
    private void Awake() {
        StateMachine = new StateMachine<Player>(this);
    }

    private void Start() {
        CharacterController = GetComponent<CharacterController2D>();
        InputHandler = GetComponent<PlayerInputHandler>();

        StateMachine.SetState(IdleState);
    }

    private void Update() {
        StateMachine.CurrentState.TickState(this);

        Debug.Log(StateMachine.CurrentState);
    }

    private void FixedUpdate() {
        StateMachine.CurrentState.FixedUpdateTick(this);
    }
}
