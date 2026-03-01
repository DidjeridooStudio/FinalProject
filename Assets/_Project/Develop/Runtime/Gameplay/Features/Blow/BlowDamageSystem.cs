using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Blow
{
    public class BlowDamageSystem : IInitializableSystem, IUpdatableSystem
    {
        private Entity _entity;
        private ReactiveVariable<float> _blowDamage;
        private Buffer<Entity> _contacts;

        private List<Entity> _processedEntities;

        #region Interface

        public void OnInit(Entity entity)
        {
            _entity = entity;
            _blowDamage = entity.BlowDamage;
            _contacts = entity.ContactsEntitiesBuffer;

            _processedEntities = new List<Entity>(_contacts.Items.Length);
        }

        public void OnUpdate(float deltaTime)
        {
            for (int i = 0; i < _contacts.Count; i++)
            {
                Entity contactEntity = _contacts.Items[i];

                if (_processedEntities.Contains(contactEntity) == false)
                {
                    _processedEntities.Add(contactEntity);

                    EntitiesHepler.TryTakeDamageFrom(_entity, contactEntity, _blowDamage.Value);
                }
            }

            if (_contacts.Count > 0)
                _contacts.Count = 0;

            for (int i = _processedEntities.Count - 1; i >= 0; i--)
                if (ContainInContacts(_processedEntities[i]) == false)
                    _processedEntities.RemoveAt(i);
        }

        #endregion

        private bool ContainInContacts(Entity entity)
        {
            for (int i = 0; i < _contacts.Count; i++)
                if (_contacts.Items[i] == entity)
                    return true;

            return false;
        }
    }
}
