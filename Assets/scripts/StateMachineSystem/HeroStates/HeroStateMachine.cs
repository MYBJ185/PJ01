using System;
using System.Collections.Generic;
using Characters.Hero;
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
        
        private HeroController _heroController;
        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            StateTable = new Dictionary<Type, IState>(states.Length);
            _input = GetComponent<InputHandler>();
            _heroController = GetComponent<HeroController>();
            foreach (var state in states)
            {
                state.Initialize(this, _input, _heroController, _animator);
                StateTable.Add(state.GetType(), state);
            }
        }

        private void Start()
        {
            SwitchState(StateTable[typeof(HeroStateIdle)]);
        }
    }
}