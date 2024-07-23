using System;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineSystem.Base
{
    public class StateMachine : MonoBehaviour
    {
        private IState _currentState;
        public Dictionary<System.Type, IState> StateTable;
        private void Update()
        {
            _currentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            _currentState.PhysicUpdate();
        }
        
        private void SwitchOn(IState newState)
        {
            _currentState = newState;
            _currentState.Enter();
        }
        
        public void SwitchState(IState newState)
        {            
            _currentState?.Exit();
            SwitchOn(newState);
        }
        
        public void SwitchState(System.Type newState)
        {
            _currentState?.Exit();
            SwitchOn(StateTable[newState]);
        }
    }
}