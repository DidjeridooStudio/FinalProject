using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class RandomMovementState : State, IUpdatebableState
    {
        private ReactiveVariable<Vector3> _moveDirection;
        private ReactiveVariable<Vector3> _rotateDirection;

        private float _cooldownBetweenDirectionGeneration;
        private float _time;

        public RandomMovementState(Entity entity, float cooldownBetweenDirectionGeneration)
        {
            _moveDirection = entity.MoveDirection;
            _rotateDirection = entity.RotateDirection;
            _cooldownBetweenDirectionGeneration = cooldownBetweenDirectionGeneration;
        }

        public override void Enter()
        {
            base.Enter();

            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

            _moveDirection.Value = randomDirection;
            _rotateDirection.Value = randomDirection;

            _time = 0;
        }

        public override void Exit()
        {
            base.Exit();

            _moveDirection.Value = Vector3.zero;
        }

        public void Update(float deltaTime)
        {
            _time += deltaTime;

            if (_time >= _cooldownBetweenDirectionGeneration)
            {
                GenerateNewDirection();
                _time = 0;
            }
        }

        private void GenerateNewDirection()
        {
            Vector3 inverseDirection = -_moveDirection.Value.normalized;

            Quaternion randomTurn = Quaternion.Euler(0, Random.Range(-30, 30), 0);

            _moveDirection.Value = randomTurn * inverseDirection;
            _rotateDirection.Value = _moveDirection.Value;
        }
    }
}
