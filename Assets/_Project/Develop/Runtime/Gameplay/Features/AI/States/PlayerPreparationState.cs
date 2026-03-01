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
        private IInputService _inputService;
        private PlayerEntityConfig _playerEntityConfig;
        private WalletService _walletService;
        private CollidersRegistryService _collidersRegistryService;

        public PlayerPreparationState(Entity entity, IInputService inputService,
            PlayerEntityConfig playerEntityConfig, WalletService walletService, CollidersRegistryService collidersRegistryService)
        {
            _inputService = inputService;
            _playerEntityConfig = playerEntityConfig;
            _walletService = walletService;
            _collidersRegistryService = collidersRegistryService;
        }

        public void Update(float deltaTime)
        {
            if (_inputService.LeftMouseButtonClicked)
            {
                if (_walletService.EnoughCurrency(CurrencyTypes.Gold, _playerEntityConfig.MinePrice) == false)
                {
                    Debug.Log("Not enough money");
                    Debug.Log($"Current money {_walletService.GetCurrency(CurrencyTypes.Gold).Value}");
                    return;
                }

                Ray ray = Camera.main.ScreenPointToRay(_inputService.MousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    Mine mine = Object.Instantiate(_playerEntityConfig.MinePrefab, hitInfo.point, Quaternion.identity);
                    mine.Initialize(_collidersRegistryService);
                    _walletService.SpendCurrency(CurrencyTypes.Gold, _playerEntityConfig.MinePrice);
                    Debug.Log($"Current money {_walletService.GetCurrency(CurrencyTypes.Gold).Value}");
                }
            }
        }
    }
}
