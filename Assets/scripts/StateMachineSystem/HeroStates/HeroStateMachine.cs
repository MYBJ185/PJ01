using System;
using System.Collections.Generic;
using Input;
using UnityEngine;
using StateMachine = StateMachineSystem.Base.StateMachine;
using IState = StateMachineSystem.Base.IState;
namespace StateMachineSystem.HeroStates
{
    public class HeroStateMachine : StateMachine
    {
        [SerializeField] 
        private HeroState[] states;
        
        private Animator _animator;
        
        private InputHandler _input;
        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            StateTable = new Dictionary<Type, IState>(states.Length);
            _input = GetComponent<InputHandler>();
            foreach (var state in states)
            {
                state.Initialize(this, _input, _animator);
                StateTable.Add(state.GetType(), state);
            }
        }

        private void Start()
        {
            SwitchState(StateTable[typeof(HeroStateIdle)]);
        }
    }
}