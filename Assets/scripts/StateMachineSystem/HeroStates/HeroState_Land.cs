using UnityEngine;

namespace StateMachineSystem.HeroStates
{
    [CreateAssetMenu(menuName = "Data/StateMachine/HeroState/Land", fileName = "HeroState_Land")]
    public class HeroStateLand : HeroState
    {
        [SerializeField] private float stiffTime = 0.5f;
        public override void Enter()
        {
            base.Enter();
            HeroController.SetVelocity(Vector3.zero);
        }
        public override void LogicUpdate()
        {
            if (Input.Jump)
            {
                StateMachine.SwitchState(typeof(HeroStateJumpUp));
            }
            if(StateDuration < stiffTime)
            {
                return;
            }
            if (Input.Move)
            {
                StateMachine.SwitchState(typeof(HeroStateWalk));
            }
            if (IsAnimationFinished)
            {
                StateMachine.SwitchState(typeof(HeroStateIdle));
            }
        }
    }
}