using UnityEngine;

namespace StateMachineSystem.HeroStates
{
    [CreateAssetMenu(menuName = "Data/StateMachine/HeroState/Fall", fileName = "HeroState_Fall")]
    public class HeroStateFall : HeroState
    {
        [SerializeField] private AnimationCurve fallSpeed;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float fallForce = 10f;
        public override void Enter()
        {
            base.Enter();
            HeroController.SetVelocityX(0);
        }
        public override void LogicUpdate()
        {
            if (HeroController.IsGrounded)
            {
                StateMachine.SwitchState(typeof(HeroStateLand));
            }
            if (Input.Jump && !HeroController.CanAirJump)
            {
                Input.SetJumpInputBuffer();
            }
            if (Input.Jump && HeroController.CanAirJump)
            {
                StateMachine.SwitchState((typeof(HeroStateAirJump)));
            }


        }
        
        public override void PhysicUpdate()
        {
            HeroController.SetVelocityY(fallSpeed.Evaluate(StateDuration) * (-fallForce));
            HeroController.Move(moveSpeed);
        }
    }
}