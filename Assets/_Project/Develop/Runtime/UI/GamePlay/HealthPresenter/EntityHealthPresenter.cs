using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.GamePlay.HealthPresenter
{
    public class EntityHealthPresenter : IPresenter
    {
        private BarWithText _bar;
        private Entity _entity;
        private ReactiveVariable<Teams> _team;
        private ReactiveVariable<float> _health;
        private ReactiveVariable<float> _maxHealth;

        private List<IDisposable> _disposables = new List<IDisposable>();

        public EntityHealthPresenter(BarWithText bar, Entity entity)
        {
            _bar = bar;
            _entity = entity;
        }

        public BarWithText Bar => _bar;

        public void Initialize()
        {
            _health = _entity.CurrentHealth;
            _maxHealth = _entity.MaxHealth;
            _team = _entity.Team;

            _disposables.Add(_health.Subcribe(OnHealthChanged));
            _disposables.Add(_maxHealth.Subcribe(OnMaxHealthChanged));
            _disposables.Add(_team.Subcribe(OnTeamChanged));

            UpdateHealth();
            UpdateFillerColorBy(_team.Value);
        }

        public void Dispose()
        {
            foreach (IDisposable disposable in _disposables)
                disposable.Dispose();
        }

        private void UpdateHealth()
        {
            _bar.UpdateText(_health.Value.ToString("0"));
            _bar.UpdateValue(_health.Value/_maxHealth.Value);
        }

        private void UpdateFillerColorBy(Teams team)
        {
            if (team == Teams.MainHero)
                _bar.SetFillerColor(Color.green);
            else if (team == Teams.Enemies)
                _bar.SetFillerColor(Color.red);
        }

        private void OnHealthChanged(float oldValue, float newValue) => UpdateHealth();

        private void OnMaxHealthChanged(float oldValue, float newValue) => UpdateHealth();

        private void OnTeamChanged(Teams oldTeam, Teams newTeam) => UpdateFillerColorBy(newTeam);
    }
}
