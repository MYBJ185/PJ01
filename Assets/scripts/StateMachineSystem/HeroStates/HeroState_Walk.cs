using Tool.Debug;
using UnityEngine;
using UnityEngine.Serialization;

namespace StateMachineSystem.HeroStates
{
    [CreateAssetMenu(menuName = "Data/StateMachine/HeroState/Walk", fileName = "HeroState_Walk")]
    public class HeroStateWalk : HeroState
    {
        [FormerlySerializedAs("runSpeed")] [SerializeField] private float walkSpeed = 2f;
        [SerializeField] private float acceleration = 5f;
        private float _previousAxisX;
        public override void Enter()
        {
            base.Enter();
            CurrentSpeed = HeroController.MoveSpeed;
            _previousAxisX = Input.AxisX;
        }
        
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (HeroController.IsDirectionChanged)
            {
                StateMachine.SwitchState(typeof(HeroStateTurn));
            }
            if (Mathf.Abs(Input.AxisX) >= 0.8 && IsAnimationFinished)
            {
                StateMachine.SwitchState(typeof(HeroStateRun));
            }
            if (!Input.Move)
            {
                StateMachine.SwitchState(typeof(HeroStateIdle));
            }
            if (Input.Jump)
            {
                StateMachine.SwitchState(typeof(HeroStateJumpUp));
            }
            if(!HeroController.IsGrounded)
            {
                StateMachine.SwitchState(typeof(HeroStateCoyoteTime));
            }
            if (!Mathf.Approximately(Mathf.Sign(Input.AxisX), Mathf.Sign(_previousAxisX)))
            {
                //DebugConsole.Instance.Log("Direction changed", LogLevel.Info);
            }

            _previousAxisX = Input.AxisX;
            CurrentSpeed = Mathf.MoveTowards(CurrentSpeed, walkSpeed,acceleration * Time.deltaTime);
        }

        public override void PhysicUpdate()
        {
            HeroController.Move(CurrentSpeed);
        }
    }
}