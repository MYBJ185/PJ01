using UnityEngine;
namespace StateMachineSystem.HeroStates
{
    [CreateAssetMenu(menuName = "Data/StateMachine/HeroState/AirJump", fileName = "HeroState_AirJump")]
    public class HeroStateAirJump : HeroState
    {
        [SerializeField] private AnimationCurve jumpSpeed;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float moveSpeed = 5f;
        
        public override void Enter()
        {
            base.Enter();
            HeroController.SetVelocityY(0);
            HeroController.CanAirJump = false;
        }
        public override void LogicUpdate()
        {
            if( HeroController.IsFalling)
            {
                StateMachine.SwitchState(typeof(HeroStateFall));
            }
        }

        public override void PhysicUpdate()
        {
            HeroController.SetVelocityY(jumpSpeed.Evaluate(StateDuration) * (jumpForce + 1) - 1f);
            HeroController.Move(moveSpeed);
        }
    }
}