using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.Utilies;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.StageFeature
{
    public class PreparationTriggerService
    {
        private ReactiveVariable<bool> _hasMainHeroContact = new ReactiveVariable<bool>();
        private EntitiesFactory _entitiesFactory;
        private EntitiesLifeContext _entitiesLifeContext;
        private Entity _nextStageTrigger;
        private Buffer<Entity> _nextStageTriggerContacts;

        public PreparationTriggerService(EntitiesFactory entitiesFactory, EntitiesLifeContext entitiesLifeContext)
        {
            _entitiesFactory = entitiesFactory;
            _entitiesLifeContext = entitiesLifeContext;
        }

        public IReadOnlyVariable<bool> HasMainHeroContact => _hasMainHeroContact;

        public void Create(Vector3 position)
        {
            if (_nextStageTrigger != null)
                throw new InvalidOperationException("Trigger already created");

            _nextStageTrigger = _entitiesFactory.CreateContactTriggerEntity(position);
            _nextStageTriggerContacts = _nextStageTrigger.ContactsEntitiesBuffer;
        }

        public void Update(float deltaTime)
        {
            if (_nextStageTrigger == null)
                return;

            for (int i = 0; i < _nextStageTriggerContacts.Count; i++)
            {
                Entity contact = _nextStageTriggerContacts.Items[i];

                if (contact.HasComponent<IsMainHero>())
                {
                    _hasMainHeroContact.Value = true;
                    return;
                }
            }
        }

        public void Cleanup()
        {
            _entitiesLifeContext.Release(_nextStageTrigger);
            _hasMainHeroContact.Value = false;
            _nextStageTrigger = null;
            _nextStageTriggerContacts = null;
        }
    }
}
