using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI
{
    public class AIParallelState : ParallelState<IUpdatebableState>, IUpdatebableState
    {
        public AIParallelState(params IUpdatebableState[] states) : base(states)
        {
        }

        public void Update(float deltaTime)
        {
            foreach(IUpdatebableState state in States)
                state.Update(deltaTime);
        }
    }
}
