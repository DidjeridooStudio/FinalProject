using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Meta.Wallet
{
    [CreateAssetMenu(menuName = "Configs/Start Wallet Config", fileName = "StartWalletConfig")]
    public class StartWalletConfig : ScriptableObject
    {
        [SerializeField] private List<CurrencyConfig> _values;

        public int GetValueFor(CurrencyTypes currencyType) => _values.First(config => config.Type == currencyType).Value;

        [Serializable]
        private class CurrencyConfig
        {
            [field: SerializeField] public CurrencyTypes Type { get; private set; }
            [field: SerializeField] public int Value { get; private set; }
        }

        public List<CurrencyTypes> AvailableCurrencies()
        {
            List<CurrencyTypes> currencyTypes = new List<CurrencyTypes>();

            foreach (CurrencyConfig config in _values)
                currencyTypes.Add(config.Type);

            return currencyTypes;
        }
    }
}

