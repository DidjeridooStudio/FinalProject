using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class BlowState : State, IUpdatebableState
    {
        private ReactiveEvent<Vector3> _blowRequest;
        private Transform _transform;

        public BlowState(Entity entity)
        {
            _transform = entity.Transform;
            _blowRequest = entity.BlowRequest;
        }

        public override void Enter()
        {
            base.Enter();

            _blowRequest.Invoke(_transform.position);
        }

        public void Update(float deltaTime)
        {
            
        }
    }
}
