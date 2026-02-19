using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;

namespace Assets._Project.Develop.Runtime.Utilies.Timer
{
    public class TimerServiceFactory
    {
        private readonly DIContainer _container;

        public TimerServiceFactory(DIContainer container)
        {
            _container = container;
        }

        public TimerService Create(float cooldown) => new TimerService(cooldown, _container.Resolve<ICoroutinesPerformer>());
    }
}
