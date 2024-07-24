namespace StateMachineSystem.Base
{
    public interface IState
    {
        string StateName { get; }
        void Enter();
        void Exit();
        void LogicUpdate();
        void PhysicUpdate();
    }
}