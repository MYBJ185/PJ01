using UnityEngine;
    
namespace StateMachineSystem.HeroStates
{
    [CreateAssetMenu(menuName = "Data/StateMachine/HeroState/Run", fileName = "HeroState_Run")]
    public class HeroStateRun : HeroState
    {
        [SerializeField] private float runSpeed = 5f;
        [SerializeField] private float acceleration = 10f;
        public override void Enter()
        {
            base.Enter();
            CurrentSpeed = HeroController.MoveSpeed;
        }
        
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Mathf.Abs(Input.AxisX) <= 0.8)
            {
                StateMachine.SwitchState(typeof(HeroStateIdle));
            }
            
            CurrentSpeed = Mathf.MoveTowards(CurrentSpeed, runSpeed,acceleration * Time.deltaTime);
        }

        public override void PhysicUpdate()
        {
            HeroController.Move(CurrentSpeed);
        }
    }
}