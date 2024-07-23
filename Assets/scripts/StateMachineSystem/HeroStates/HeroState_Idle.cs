using UnityEngine;
using UnityEngine.InputSystem;

namespace StateMachineSystem.HeroStates
{
    [CreateAssetMenu(menuName = "Data/StateMachine/HeroState/Idle", fileName = "HeroState_Idle")]
    public class HeroStateIdle : HeroState
    {
        public override void Enter()
        {
            base.Enter();
            Animator.Play("Idle");
        }
        
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Input.Move)
            {
                StateMachine.SwitchState(typeof(HeroStateRun));
            }
        }
    }
}