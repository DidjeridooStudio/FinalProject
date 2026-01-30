using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilies.LoadingScreen
{
    public class StandartLoadingScreen : MonoBehaviour, ILoadingScreen
    {
        #region Interface

        public bool IsShown => gameObject.activeSelf;

        #endregion

        private void Awake()
        {
            Hide();
            DontDestroyOnLoad(this);
        }

        #region Interface

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);

        #endregion
    }
}