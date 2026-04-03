using Assets._Project.Develop.Runtime.Configs.Gameplay;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.Tower;
using Assets._Project.Develop.Runtime.Utilies.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;
using UnityEngine.EventSystems;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class PlayerPreparationState : State, IUpdatebableState
    {
        private Entity _player;
        private Entity _tower;
        private IInputService _inputService;
        private EntitiesLifeContext _entitiesLifeContext;

        public PlayerPreparationState(Entity entity, IInputService inputService,
            TowerHolderService towerHolderService,
            EntitiesLifeContext entitiesLifeContext)
        {
            _player = entity;
            _inputService = inputService;
            _tower = towerHolderService.Tower;
            _entitiesLifeContext = entitiesLifeContext;
        }

        public override void Enter()
        {
            base.Enter();

            _player.TowerHealRequest?.Invoke(_tower);

            foreach (var entity in _entitiesLifeContext.Entities)
                if(entity.HasComponent<IsClearAfterStage>())
                    entity.EndClearAllEnemiesStageEvent?.Invoke();
        }

        public void Update(float deltaTime)
        {
            if (_inputService.LeftMouseButtonClicked && EventSystem.current.IsPointerOverGameObject() == false)
            {
                if (_player.ProtectionObjectConfig.Value != null)
                    _player.MineSpawnRequest?.Invoke(_player.ProtectionObjectConfig.Value);
            }
        }

        public override void Exit()
        {
            base.Exit();

            _player.ProtectionObjectConfig.Value = null;
        }
    }
}
