using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

public class Player : MonoBehaviour
{
    #region PlayerFSM
    public PlayerIdleState IdleState = new PlayerIdleState(); 
    #endregion

    public CharacterController2D CharacterController { get; private set; }

    public StateMachine<Player> StateMachine;
    
    private void Awake() {
        StateMachine = new StateMachine<Player>(this);

        StateMachine.SetState(IdleState);
    }

    private void Start() {
        CharacterController = GetComponent<CharacterController2D>();
    }

    private void Update() {
        StateMachine.CurrentState.TickState(this);
    }
}
