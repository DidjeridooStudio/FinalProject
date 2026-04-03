using Assets._Project.Develop.Runtime.Configs.Gameplay;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.Tower;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Blow
{
    public class MineSpawnOnMoneySystem : IInitializableSystem, IDisposableSystem
    {
        private PlayersEntitiesFactory _playersEntitiesFactory;
        private WalletService _walletService;
        private RaycastOnMousePositionService _raycastOnMousePositionService;

        private ReactiveEvent<EntityConfig> _mineSpawnRequest;

        private IDisposable _mineSpawnRequestDisposable;

        public MineSpawnOnMoneySystem(PlayersEntitiesFactory playersEntitiesFactory,
            WalletService walletService, RaycastOnMousePositionService raycastOnMousePositionService)
        {
            _playersEntitiesFactory = playersEntitiesFactory;
            _walletService = walletService;
            _raycastOnMousePositionService = raycastOnMousePositionService;
        }

        #region Interface

        public void OnInit(Entity entity)
        {
            _mineSpawnRequest = entity.MineSpawnRequest;

            _mineSpawnRequestDisposable = _mineSpawnRequest.Subcribe(OnMineSpawnRequest);
        }

        public void OnDispose()
        {
            _mineSpawnRequestDisposable.Dispose();
        }

        #endregion

        private void OnMineSpawnRequest(EntityConfig entityConfig)
        {
            switch (entityConfig)
            {
                case MineEntityConfig mineEntityConfig:
                    CreateMineEntity(mineEntityConfig);
                    break;
                case ToxicPuddleConfig toxicPuddleConfig:
                    CreateToxicPuddleEntity(toxicPuddleConfig);
                    break;
                case TurretEntityConfig turretEntityConfig:
                    CreateTurretPuddleEntity(turretEntityConfig);
                    break;
                default:
                    throw new ArgumentException($"Not support {entityConfig.GetType()} type of configs");
            }
        }

        private void CreateMineEntity(MineEntityConfig mineEntityConfig)
        {
            if (_walletService.EnoughCurrency(CurrencyTypes.Gold, mineEntityConfig.SpawnPrice) == false)
                return;

            Vector3 raycastHitPoint = _raycastOnMousePositionService.RaycastHitPoint();
            if (raycastHitPoint != Vector3.zero)
            {
                _playersEntitiesFactory.CreateMineEntity(raycastHitPoint, mineEntityConfig);
                _walletService.SpendCurrency(CurrencyTypes.Gold, mineEntityConfig.SpawnPrice);
            }
        }

        private void CreateToxicPuddleEntity(ToxicPuddleConfig toxicPuddleConfig)
        {
            if (_walletService.EnoughCurrency(CurrencyTypes.Gold, toxicPuddleConfig.SpawnPrice) == false)
                return;

            Vector3 raycastHitPoint = _raycastOnMousePositionService.RaycastHitPoint();
            if (raycastHitPoint != Vector3.zero)
            {
                _playersEntitiesFactory.CreateToxicPuddleEntity(raycastHitPoint, toxicPuddleConfig);
                _walletService.SpendCurrency(CurrencyTypes.Gold, toxicPuddleConfig.SpawnPrice);
            }
        }

        private void CreateTurretPuddleEntity(TurretEntityConfig turretEntityConfig)
        {
            if (_walletService.EnoughCurrency(CurrencyTypes.Gold, turretEntityConfig.SpawnPrice) == false)
                return;

            Vector3 raycastHitPoint = _raycastOnMousePositionService.RaycastHitPoint();
            if (raycastHitPoint != Vector3.zero)
            {
                _playersEntitiesFactory.CreateTurretEntity(raycastHitPoint, turretEntityConfig);
                _walletService.SpendCurrency(CurrencyTypes.Gold, turretEntityConfig.SpawnPrice);
            }
        }
    }
}
