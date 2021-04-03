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
    public PlayerNPCState NPCState = new PlayerNPCState();
    #endregion

    public CharacterController2D CharacterController { get; private set; }

    public StateMachine<Player> StateMachine;

    public PlayerInputHandler InputHandler { get; private set; }

    public Damageable.Damageable PlayerHealth { get; private set;}

    public Collider2D Collider;

    public PlayerAnimationHandler AnimationHandler { get; private set; }
    
    private void Awake() {
        StateMachine = new StateMachine<Player>(this);
        PlayerHealth = GetComponent<Damageable.Damageable>();
        AnimationHandler = GetComponent<PlayerAnimationHandler>();
    }

    private void Start() {
        CharacterController = GetComponent<CharacterController2D>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Collider = GetComponent<Collider2D>();

        StateMachine.SetState(IdleState);
    }

    private void Update() {
        StateMachine.CurrentState.TickState(this);
    }

    private void FixedUpdate() {
        StateMachine.CurrentState.FixedUpdateTick(this);
    }
}
