using UnityEngine;

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
        Debug.Log("Количество выигрышей " + _progressionService.WinningsQuantity);
        Debug.Log("Количество поражений " + _progressionService.LossesQuantity);
        Debug.Log("Запас золота " + _walletService.GetCurrency(CurrencyTypes.Gold).Value);
    }

    private void ResetProgress()
    {
        LevelConfig levelConfig = _configsProviderService.GetConfig<LevelConfig>();

        Debug.Log($"Для сброса прогресса требуется {levelConfig.MoneyToResetProgress} золотых");

        if (_walletService.EnoughCurrency(CurrencyTypes.Gold, levelConfig.MoneyToResetProgress))
        {
            _progressionService.Reset();
            _walletService.SpendCurrency(CurrencyTypes.Gold, levelConfig.MoneyToResetProgress);
            Debug.Log("Прогресс успешно сброшен");
        }
        else
        {
            Debug.Log("У вас недостаточно золота");
        }
    }
}
