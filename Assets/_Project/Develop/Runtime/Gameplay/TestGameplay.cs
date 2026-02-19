using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;
        private EntitiesFactory _entitiesFactory;
        private BrainsFactory _brainsFactory;

        private Entity _entity;
        private Entity _ghost;

        private bool _isRunning;

        public void Initialize(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _brainsFactory = _container.Resolve<BrainsFactory>();
        }

        public void Run()
        {
            // L_6 1a
            //_entity = _entitiesFactory.CreateTeleportingEntity(Vector3.zero);
            //_brainsFactory.CreateRandomTeleportingEntityBrain(_entity);

            // L_6 1b
            //_entity = _entitiesFactory.CreateTeleportingEntity(Vector3.zero);
            //_entity.AddCurrentTarget();
            //_brainsFactory.CreateLessHealthTargetTeleportingEntityBrain(_entity, new LessHealthTargetSelector(_entity));

            // L_6 2
            Entity ghost1 = _entitiesFactory.CreateGhostEntity(Vector3.zero + Vector3.back * 5);
            _brainsFactory.CreateGhostBrain(ghost1);
            Entity ghost2 =  _entitiesFactory.CreateGhostEntity(Vector3.zero + Vector3.left * 5);
            _brainsFactory.CreateGhostBrain(ghost2);
            Entity ghost3 =  _entitiesFactory.CreateGhostEntity(Vector3.zero + Vector3.right * 5);
            _brainsFactory.CreateGhostBrain(ghost3);
            Entity ghost4 = _entitiesFactory.CreateGhostEntity(Vector3.zero + Vector3.forward * 5);
            _brainsFactory.CreateGhostBrain(ghost4);

            _entity = _entitiesFactory.CreateHeroEntity(Vector3.zero);
            _brainsFactory.CreateMainHeroBrainL_6(_entity);

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
