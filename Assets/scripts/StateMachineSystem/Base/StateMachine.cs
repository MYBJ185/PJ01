using System;
using System.Collections.Generic;
using Tool.Debug;
using UnityEngine;

namespace StateMachineSystem.Base
{
    public class StateMachine : MonoBehaviour
    {
        private IState _currentState;
        protected Dictionary<Type, IState> StateTable;
        
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
            
            var debugConsoleInstance = DebugConsole.Instance;
            if (debugConsoleInstance)
            {
                debugConsoleInstance.Log(_currentState.StateName, LogLevel.Info);
            }
        }
        
        protected void SwitchState(IState newState)
        {            
            _currentState?.Exit();
            SwitchOn(newState);
        }
        
        public void SwitchState(Type newState)
        {
            _currentState?.Exit();
            SwitchOn(StateTable[newState]);
        }
    }
}