using Characters.Hero;
using Input;
using StateMachineSystem.Base;
using UnityEngine;

namespace StateMachineSystem.HeroStates
{
    public class HeroState : ScriptableObject, IState
    {
        
        protected Animator Animator;
        protected HeroController HeroController;
        protected InputHandler Input;
        protected HeroStateMachine StateMachine;
        
        public void Initialize(HeroStateMachine stateMachine, InputHandler input,HeroController hc, Animator animator)
        {
            StateMachine = stateMachine;
            HeroController = hc;
            Input = input;
            Animator = animator;
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