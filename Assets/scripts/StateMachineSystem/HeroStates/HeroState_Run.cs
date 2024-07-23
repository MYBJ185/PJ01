using UnityEngine;
using UnityEngine.InputSystem;
    
namespace StateMachineSystem.HeroStates
{
    [CreateAssetMenu(menuName = "Data/StateMachine/HeroState/Run", fileName = "HeroState_Run")]
    public class HeroStateRun : HeroState
    {
        public override void Enter()
        {
            base.Enter();
            Animator.Play("Run");
        }
        
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (!Input.Move)
            {
                StateMachine.SwitchState(typeof(HeroStateIdle));
            }
        }
    }
}