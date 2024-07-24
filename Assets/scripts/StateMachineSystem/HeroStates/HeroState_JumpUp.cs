using Characters.Hero;
using Unity.VisualScripting;
using UnityEngine;

namespace StateMachineSystem.HeroStates
{
    [CreateAssetMenu(menuName = "Data/StateMachine/HeroState/JumpUp", fileName = "HeroState_JumpUp")]
    public class HeroStateJumpUp : HeroState
    {
        [SerializeField] private AnimationCurve jumpSpeed;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float moveSpeed = 5f;
        public override void Enter()
        {
            base.Enter();
            //HeroController.SetVelocityY(jumpForce);
        }
        public override void LogicUpdate()
        {
            if(Input.StopJump || HeroController.IsFalling)
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