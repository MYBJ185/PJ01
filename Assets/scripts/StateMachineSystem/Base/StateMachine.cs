using System;
using System.Collections.Generic;
using Tool.Debug;
using UnityEngine;

namespace StateMachineSystem.Base
{
    public class StateMachine : MonoBehaviour
    {
        private IState _currentState;
        protected Dictionary<System.Type, IState> StateTable;
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
            if (DebugConsole.Instance)
            {
                DebugConsole.Instance.Log("角色状态切换:" + _currentState.StateName, LogLevel.Info);
            }
        }
        
        protected void SwitchState(IState newState)
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