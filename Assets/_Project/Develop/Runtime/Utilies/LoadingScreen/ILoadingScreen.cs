namespace Assets._Project.Develop.Runtime.Utilies.LoadingScreen
{
    public interface ILoadingScreen
    {
        bool IsShown { get; }
        void Show();
        void Hide();
    }
}