using Assets._Project.Develop.Runtime.Configs.Gameplay;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.Blow;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class PlayerPreparationState : State, IUpdatebableState
    {
        private Entity _player;
        private IInputService _inputService;

        public PlayerPreparationState(Entity entity, IInputService inputService)
        {
            _player = entity;
            _inputService = inputService;
        }

        public void Update(float deltaTime)
        {
            if (_inputService.LeftMouseButtonClicked)
            {
                _player.MineSpawnRequest?.Invoke();
            }
        }
    }
}
