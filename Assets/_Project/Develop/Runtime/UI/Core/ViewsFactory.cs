using Assets._Project.Develop.Runtime.Utilies.AssetsManagment;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets._Project.Develop.Runtime.UI.Core
{
    public class ViewsFactory
    {
        private readonly ResourcesAssetsLoader _resourcesAssetsLoader;

        private readonly Dictionary<string, string> _viewIDToResourcesPath = new Dictionary<string, string>()
        {
            {ViewsIDs.CurrencyView, "UI/CurrencyView" },
            {ViewsIDs.MainMenuScreenView, "UI/MainMenuScreenView" },
            {ViewsIDs.GameplayScreenView, "UI/GameplayScreenView" },
            {ViewsIDs.StartGamePopup, "UI/StartGamePopup" },
            {ViewsIDs.ResetProgressPopup, "UI/ResetProgressPopup" },
            {ViewsIDs.MessagePopup, "UI/MessagePopup" },
            {ViewsIDs.CheckProgressPopup, "UI/CheckProgressPopup" },
            {ViewsIDs.WinPopup, "UI/WinPopup" },
            {ViewsIDs.DefeatPopup, "UI/DefeatPopup" },
            {ViewsIDs.HealthBar, "UI/HealthBar" },
            {ViewsIDs.SimpleHealthBar, "UI/SimpleHealthBar" },
            {ViewsIDs.PreparationStatePopup, "UI/PreparationStatePopup" },
            {ViewsIDs.UpgradableStatView, "UI/StatsUpgradePopup/UpgradableStatView" },
            {ViewsIDs.StatsUpgradePopupView, "UI/StatsUpgradePopup/StatsUpgradePopupView" },
        };

        public ViewsFactory(ResourcesAssetsLoader resourcesAssetsLoader)
        {
            _resourcesAssetsLoader = resourcesAssetsLoader;
        }

        public TView Create<TView>(string viewID, Transform parent = null) where TView : MonoBehaviour, IView
        {
            if (_viewIDToResourcesPath.TryGetValue(viewID, out string resourcePath) == false)
                throw new ArgumentException($"Path for {typeof(TView)} didn't set. Searched ID {viewID}");

            GameObject prefab = _resourcesAssetsLoader.Load<GameObject>(resourcePath);
            GameObject instance = Object.Instantiate(prefab, parent);

            TView view = instance.GetComponent<TView>();

            if (view == null)
                throw new InvalidOperationException($"Component {typeof(TView)} not found on view instance");

            return view;
        }

        public void Release<TView>(TView view) where TView : MonoBehaviour, IView
        {
            Object.Destroy(view.gameObject);
        }

        internal T Create<T>(object upgradableStatView)
        {
            throw new NotImplementedException();
        }
    }
}
