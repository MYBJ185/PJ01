using Characters.Hero;
using Input;
using StateMachineSystem.Base;
using Tool.Debug;
using UnityEngine;

namespace StateMachineSystem.HeroStates
{
    public class HeroState : ScriptableObject, IState
    {
        [SerializeField] private string stateName;

        [SerializeField, Range(0, 1)] private float transitionDuration = 0.1f;
        private float _stateStartTime;
        private int _stateHash;
        private Animator _animator;
        protected float StateDuration => Time.time - _stateStartTime;
        protected float CurrentSpeed;
        protected HeroController HeroController;
        protected InputHandler Input;
        protected HeroStateMachine StateMachine;
        protected bool IsAnimationFinished => StateDuration >= _animator.GetCurrentAnimatorStateInfo(0).length;

        public string StateName => stateName;
        private void OnEnable()
        {
            _stateHash = Animator.StringToHash(stateName);

        }

        public void Initialize(HeroStateMachine stateMachine, InputHandler input,HeroController hc, Animator animator)
        {
            StateMachine = stateMachine;
            HeroController = hc;
            Input = input;
            _animator = animator;
        }
        public virtual void Enter()
        {
            _stateStartTime = Time.time;
            //不使用交叉叠化，直接播放动画
            _animator.Play(_stateHash);
            //_animator.CrossFade(_stateHash, transitionDuration);
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