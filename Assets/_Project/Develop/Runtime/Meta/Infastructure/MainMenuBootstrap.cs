using Assets._Project.Develop.Runtime.Infastructure;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;
using System.Collections;

namespace Assets._Project.Develop.Runtime.Meta.Infastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistrations.Process(_container);
        }

        public override IEnumerator Initialize()
        {
            yield break;
        }

        public override void Run()
        {

        }

        private void Update()
        {

        }
    }
}