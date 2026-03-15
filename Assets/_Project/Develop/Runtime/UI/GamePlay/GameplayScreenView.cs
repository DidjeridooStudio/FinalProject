using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.GamePlay.HealthPresenter;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.GamePlay
{
    public class GameplayScreenView : MonoBehaviour, IView
    {
        [field: SerializeField] public IconTextListView WalletView { get; private set; }
        [field: SerializeField] public IconTextView StageView { get; private set; }
        [field: SerializeField] public EntitiesHealthDisplay EntitiesHealthDisplay { get; private set; }
    }
}
