using UnityEngine;

namespace StateMachineSystem.HeroStates
{
    [CreateAssetMenu(menuName = "Data/StateMachine/HeroState/CoyoteTime", fileName = "HeroState_CoyoteTime")]
    public class HeroStateCoyoteTime : HeroState
    {
        [SerializeField] private float runSpeed = 1f;
        [SerializeField] private float coyoteTime = 0.1f;
        public override void Enter()
        {
            base.Enter();
        }
        
        public override void LogicUpdate()
        {
            if(HeroController.IsGrounded)
            {
                StateMachine.SwitchState(typeof(HeroStateLand));
            }
            if (Input.Jump)
            {
                StateMachine.SwitchState(typeof(HeroStateJumpUp));
            }
            if (StateDuration > coyoteTime)
            {
                StateMachine.SwitchState(typeof(HeroStateFall));
            }
        }
        
        public override void PhysicUpdate()
        {
            HeroController.Move(runSpeed);
        }
    }
}