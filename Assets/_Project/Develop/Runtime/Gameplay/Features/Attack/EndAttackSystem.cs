using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack
{
    public class EndAttackSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _endAttackEvent;
        private ReactiveVariable<bool> _inAttackProcess;
        private ReactiveVariable<float> _attackProcessInitialTime;
        private ReactiveVariable<float> _attackProcessCurrentTime;

        private IDisposable _timerDisposable;

        #region Interface

        public void OnInit(Entity entity)
        {
            _endAttackEvent = entity.EndAttackEvent;
            _inAttackProcess = entity.InAttackProcess;
            _attackProcessCurrentTime = entity.AttackProcessCurrentTime;
            _attackProcessInitialTime = entity.AttackProcessInitialTime;

            _timerDisposable = _attackProcessCurrentTime.Subcribe(OnTimerChanged);
        }

        public void OnDispose()
        {
            _timerDisposable.Dispose();
        }

        #endregion

        private void OnTimerChanged(float arg1, float currentTime)
        {
            if (TimeIsDone(currentTime))
            {
                _inAttackProcess.Value = false;
                _endAttackEvent.Invoke();
            }
        }

        private bool TimeIsDone(float currentTime) => currentTime >= _attackProcessInitialTime.Value;
    }
}
