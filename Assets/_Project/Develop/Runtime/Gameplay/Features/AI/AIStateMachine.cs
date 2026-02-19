using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI
{
    public class AIStateMachine : StateMachine<IUpdatebableState>
    {
        public AIStateMachine() : base(new List<IDisposable>())
        {
        }

        public AIStateMachine(List<IDisposable> disposables) : base(disposables)
        {
        }

        protected override void UpdateLogic(float deltaTime)
        {
            base.UpdateLogic(deltaTime);

            CurrentState?.Update(deltaTime);
        }
    }
}
