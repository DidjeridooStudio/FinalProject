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
        private MineEntityConfig _mineEntityConfig;
        private WalletService _walletService;
        private PlayerEntityConfig _playerEntityConfig;
        private RaycastOnMousePositionService _raycastOnMousePositionService;

        private ReactiveEvent _mineSpawnRequest;

        private IDisposable _mineSpawnRequestDisposable;

        public MineSpawnOnMoneySystem(PlayersEntitiesFactory playersEntitiesFactory, MineEntityConfig mineEntityConfig,
            WalletService walletService, PlayerEntityConfig playerEntityConfig, RaycastOnMousePositionService raycastOnMousePositionService)
        {
            _playersEntitiesFactory = playersEntitiesFactory;
            _mineEntityConfig = mineEntityConfig;
            _walletService = walletService;
            _playerEntityConfig = playerEntityConfig;
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

        private void OnMineSpawnRequest()
        {
            if (_walletService.EnoughCurrency(CurrencyTypes.Gold, _playerEntityConfig.MinePrice) == false)
            {
                Debug.Log("Not enough money");
                Debug.Log($"Current money {_walletService.GetCurrency(CurrencyTypes.Gold).Value}");
                return;
            }

            Vector3 raycastHitPoint = _raycastOnMousePositionService.RaycastHitPoint();
            if (raycastHitPoint != Vector3.zero)
            {
                _playersEntitiesFactory.CreateMineEntity(raycastHitPoint, _mineEntityConfig);

                _walletService.SpendCurrency(CurrencyTypes.Gold, _playerEntityConfig.MinePrice);
                Debug.Log($"Current money {_walletService.GetCurrency(CurrencyTypes.Gold).Value}");
            }
        }
    }
}
