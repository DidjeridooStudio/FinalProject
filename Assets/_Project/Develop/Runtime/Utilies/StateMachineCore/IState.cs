using Assets._Project.Develop.Runtime.Utilies.Reactive;

namespace Assets._Project.Develop.Runtime.Utilies.StateMachineCore
{
    public interface IState
    {
        IReadOnlyEvent Entered { get; }
        IReadOnlyEvent Exited { get; }

        void Enter();
        void Exit();
    }
}