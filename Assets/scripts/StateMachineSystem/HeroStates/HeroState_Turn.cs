using UnityEngine;

namespace StateMachineSystem.HeroStates
{
    [CreateAssetMenu(menuName = "Data/StateMachine/HeroState/Turn", fileName = "HeroState_Turn")]
    public class HeroStateTurn : HeroState
    {
        [SerializeField] private float moveSpeed = 1f;

        public override void Enter()
        {
            base.Enter();
            HeroController.Move(moveSpeed);
        }

        public override void LogicUpdate()
        {
            HeroController.Move(moveSpeed);
            if (Input.Jump)
            {
                StateMachine.SwitchState(typeof(HeroStateJumpUp));
            }
            if (Mathf.Abs(Input.AxisX) >= 0.3 && HeroController.IsDirectionChanged)
            {
                StateMachine.SwitchState(typeof(HeroStateTurn));
            }
            if(HeroController.IsDirectionChanged)
            {
                StateMachine.SwitchState(typeof(HeroStateTurn));
            }
            if (IsAnimationFinished)
            {
                StateMachine.SwitchState(typeof(HeroStateIdle));
            }

        }
    }
}