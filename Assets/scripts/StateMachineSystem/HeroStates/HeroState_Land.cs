using UnityEngine;

namespace StateMachineSystem.HeroStates
{
    [CreateAssetMenu(menuName = "Data/StateMachine/HeroState/Land", fileName = "HeroState_Land")]
    public class HeroStateLand : HeroState
    {
        [SerializeField] private float stiffTime = 0.1f;
        public override void Enter()
        {
            base.Enter();
            HeroController.CanAirJump = true;
            HeroController.SetVelocity(Vector3.zero);
        }
        public override void LogicUpdate()
        {
            if (Input.HasJumpInputBuffer || Input.Jump)
            {
                StateMachine.SwitchState(typeof(HeroStateJumpUp));
            }
            //if (Input.Move && StateDuration > stiffTime)
            //{
            //    StateMachine.SwitchState(typeof(HeroStateWalk));
            //}
            if (StateDuration > stiffTime)
            {
                StateMachine.SwitchState(typeof(HeroStateIdle));
            }
        }
    }
}