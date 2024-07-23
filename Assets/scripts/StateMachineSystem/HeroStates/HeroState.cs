using Input;
using StateMachineSystem.Base;
using UnityEngine;

namespace StateMachineSystem.HeroStates
{
    public class HeroState : ScriptableObject, IState
    {
        
        protected Animator Animator;

        protected InputHandler Input;
        protected HeroStateMachine StateMachine;
        
        public void Initialize(HeroStateMachine stateMachine, InputHandler input,  Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
            Input = input;
        }
        public virtual void Enter()
        {
            
        }
        
        public virtual void Exit()
        {
            
        }
        
        public virtual void LogicUpdate()
        {
            
        }
        
        public virtual void PhysicUpdate()
        {
            
        }
    }
}