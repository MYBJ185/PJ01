using Tool.Debug;
using UnityEngine;

namespace StateMachineSystem.HeroStates
{
    [CreateAssetMenu(menuName = "Data/StateMachine/HeroState/Run", fileName = "HeroState_Run")]
    public class HeroStateRun : HeroState
    {
        [SerializeField] private float runSpeed = 5f;
        [SerializeField] private float acceleration = 10f;
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
            if (Mathf.Abs(Input.AxisX) <= 0.8)
            {
                StateMachine.SwitchState(typeof(HeroStateIdle));
            }
            if (Input.Jump)
            {
                StateMachine.SwitchState(typeof(HeroStateJumpUp));
            }
            if (!HeroController.IsGrounded)
            {
                StateMachine.SwitchState(typeof(HeroStateCoyoteTime));
            }

            if (!Mathf.Approximately(Mathf.Sign(Input.AxisX), Mathf.Sign(_previousAxisX)))
            {
                //DebugConsole.Instance.Log("Direction changed", LogLevel.Info);
            }

            _previousAxisX = Input.AxisX;
            CurrentSpeed = Mathf.MoveTowards(CurrentSpeed, runSpeed, acceleration * Time.deltaTime);
        }

        public override void PhysicUpdate()
        {
            HeroController.Move(CurrentSpeed);
        }
    }
}