using UnityEngine;

namespace StateMachineSystem.HeroStates
{
    [CreateAssetMenu(menuName = "Data/StateMachine/HeroState/Idle", fileName = "HeroState_Idle")]
    public class HeroStateIdle : HeroState
    {
        [SerializeField] private float deceleration = 20f;

        public override void Enter()
        {
            base.Enter();
            CurrentSpeed = HeroController.MoveSpeed;
        }

        public override void LogicUpdate()
        {
            if (Mathf.Abs(Input.AxisX) >= 0.3)
            {
                StateMachine.SwitchState(typeof(HeroStateWalk));
            }
            if (Input.Jump)
            {
                StateMachine.SwitchState(typeof(HeroStateJumpUp));
            }
            if(!HeroController.IsGrounded)
            {
                StateMachine.SwitchState(typeof(HeroStateFall));
            }
            CurrentSpeed = Mathf.MoveTowards(CurrentSpeed, 0, deceleration * Time.deltaTime);
        }

        public override void PhysicUpdate()
        {
            HeroController.SetVelocityX(CurrentSpeed * HeroController.transform.localScale.x);
        }
    }
}