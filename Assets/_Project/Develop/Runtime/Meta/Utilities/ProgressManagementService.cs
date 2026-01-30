using Assets._Project.Develop.Runtime.Configs.Meta;
using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilies.ConfigsManagment;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Utilities
{
    public class ProgressManagementService
    {
        private readonly ConfigsProviderService _configsProviderService;
        private readonly WalletService _walletService;
        private readonly ProgressionService _progressionService;

        public ProgressManagementService(WalletService walletService, ProgressionService progressionService, ConfigsProviderService configsProviderService)
        {
            _walletService = walletService;
            _progressionService = progressionService;
            _configsProviderService = configsProviderService;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                GetInfo();
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                ResetProgress();
            }
        }

        private void GetInfo()
        {
            Debug.Log("Количество выигрышей " + _progressionService.WinningsQuantity.Value);
            Debug.Log("Количество поражений " + _progressionService.LossesQuantity.Value);
            Debug.Log("Запас золота " + _walletService.GetCurrency(CurrencyTypes.Gold).Value);
        }

        private void ResetProgress()
        {
            StandardSettingsConfig standardSettingsConfig = _configsProviderService.GetConfig<StandardSettingsConfig>();

            Debug.Log($"Для сброса прогресса требуется {standardSettingsConfig.MoneyToResetProgress} золотых");

            if (_walletService.EnoughCurrency(CurrencyTypes.Gold, standardSettingsConfig.MoneyToResetProgress))
            {
                _progressionService.Reset();
                _walletService.SpendCurrency(CurrencyTypes.Gold, standardSettingsConfig.MoneyToResetProgress);
                Debug.Log("Прогресс успешно сброшен");
            }
            else
            {
                Debug.Log("У вас недостаточно золота");
            }
        }
    }
}