namespace Assets._Project.Develop.Runtime.Utilies.StateMachineCore
{
    public interface IUpdatebableState : IState
    {
        void Update(float deltaTime);
    }
}
