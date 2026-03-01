using Assets._Project.Develop.Runtime.Gameplay.Features.StageFeature;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.States
{
    public class PreparationStateUA : State, IUpdatebableState
    {
        private readonly PreparationTriggerService _triggerService;

        public PreparationStateUA(PreparationTriggerService triggerService)
        {
            _triggerService = triggerService;
        }

        public override void Enter()
        {
            base.Enter();

            Vector3 nextStageTriggerPosition = Vector3.zero + Vector3.forward*4;
            _triggerService.Create(nextStageTriggerPosition);
        }

        public void Update(float deltaTime)
        {
            _triggerService.Update(deltaTime);
        }

        public override void Exit()
        {
            base.Exit();

            _triggerService.Cleanup();
        }
    }
}
