using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.States
{
    public class GameplayStateMachine : StateMachine<IUpdatebableState>
    {
        public GameplayStateMachine() : base(new List<IDisposable>())
        {
        }

        public GameplayStateMachine(List<IDisposable> disposables) : base(disposables)
        {
        }

        protected override void UpdateLogic(float deltaTime)
        {
            base.UpdateLogic(deltaTime);

            CurrentState?.Update(deltaTime);
        }
    }
}
