using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.StateMachine{
    public class StateMachine<T>
    {
        private T _stateMachineOwner; 
        public State<T> CurrentState { get; private set; }

        ///<Summary>
        //Initilize the state machine owner
        ///</Summary>
        public StateMachine(T owner){
            _stateMachineOwner = owner;
        }

        public void SetState(State<T> newState){
            CurrentState?.ExitState(_stateMachineOwner);
            CurrentState = newState;
            CurrentState.EnterState(_stateMachineOwner);
        } 
    }
}