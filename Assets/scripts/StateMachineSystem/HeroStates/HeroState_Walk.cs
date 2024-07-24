using UnityEngine;
using UnityEngine.Serialization;

namespace StateMachineSystem.HeroStates
{
    [CreateAssetMenu(menuName = "Data/StateMachine/HeroState/Walk", fileName = "HeroState_Walk")]
    public class HeroStateWalk : HeroState
    {
        [FormerlySerializedAs("runSpeed")] [SerializeField] private float walkSpeed = 2f;
        [SerializeField] private float acceleration = 5f;
        public override void Enter()
        {
            base.Enter();
            CurrentSpeed = HeroController.MoveSpeed;
        }
        
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Mathf.Abs(Input.AxisX) >= 0.8)
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
                StateMachine.SwitchState(typeof(HeroStateFall));
            }
            CurrentSpeed = Mathf.MoveTowards(CurrentSpeed, walkSpeed,acceleration * Time.deltaTime);
        }

        public override void PhysicUpdate()
        {
            HeroController.Move(CurrentSpeed);
        }
    }
}