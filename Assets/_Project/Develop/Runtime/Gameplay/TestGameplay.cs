using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;
        private EntitiesFactory _entitiesFactory;

        private Entity _entity;

        private bool _isRunning;

        public void Initialize(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
        }

        public void Run()
        {
            _entity = _entitiesFactory.CreateTeleportingEntity(Vector3.zero);
            _entitiesFactory.CreateGhostEntity(Vector3.zero + Vector3.forward * 5);
            _entitiesFactory.CreateGhostEntity(Vector3.zero + Vector3.back * 5);
            _entitiesFactory.CreateGhostEntity(Vector3.zero + Vector3.left * 5);
            _entitiesFactory.CreateGhostEntity(Vector3.zero + Vector3.right * 5);

            //_entitiesFactory.CreateTeleportingEntity(Vector3.zero);
            //_entity = _entitiesFactory.CreateGhostEntity(Vector3.zero + Vector3.forward * 5);

            //_entity = _entitiesFactory.CreateRigidbodyEntity(Vector3.zero);
            //_entity = _entitiesFactory.CreateCharacterControllerEntity(new Vector3(1,1,1));

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

            if (Input.GetKeyDown(KeyCode.T))
                _entity.TeleportCastRequest.Invoke(5);
        }
    }
}
