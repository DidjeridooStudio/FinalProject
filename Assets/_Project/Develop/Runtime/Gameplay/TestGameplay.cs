using Assets._Project.Develop.Runtime.Configs.Gameplay;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Gameplay.Features.Enemies;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;
        private EntitiesFactory _entitiesFactory;
        private BrainsFactory _brainsFactory;

        [SerializeField] GhostConfig _ghostConfig;
        [SerializeField] HeroConfig _heroConfig;

        private Entity _entity;
        private Entity _ghost;

        private MainHeroFactory _mainHeroFactory;
        private EnemiesFactory _enemiesFactory;

        private bool _isRunning;

        public void Initialize(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _brainsFactory = _container.Resolve<BrainsFactory>();

            _mainHeroFactory = _container.Resolve<MainHeroFactory>();
            _enemiesFactory = _container.Resolve<EnemiesFactory>();
        }

        public void Run()
        {
            Entity ghost1 = _enemiesFactory.Create(Vector3.zero + Vector3.back * 5, _ghostConfig);

            _entity = _mainHeroFactory.Create(Vector3.zero);

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            //Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            //_entity.MoveDirection.Value = input;

            //if (Input.GetKeyDown(KeyCode.Space))
            //    _entity.TakeDamageRequest.Invoke(50);

            //if (Input.GetKeyDown(KeyCode.R))
            //    _entity.StartAttackRequest.Invoke();

            //if (Input.GetKeyDown(KeyCode.T))
            //    _entity.TeleportCastRequest.Invoke(5);

            //if (Input.GetKeyDown(KeyCode.B))
            //    _brainsFactory.CreateGhostBrain(_ghost);
        }
    }
}
