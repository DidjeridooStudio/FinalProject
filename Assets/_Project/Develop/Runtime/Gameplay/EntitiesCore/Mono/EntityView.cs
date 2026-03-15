using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono
{
    public abstract class EntityView : MonoBehaviour
    {
        public void Link(Entity entity)
        {
            entity.initialized += OnEntityStartedWork;
        }

        public virtual void Cleanup(Entity entity)
        {
            entity.initialized -= OnEntityStartedWork;
        }

        protected abstract void OnEntityStartedWork(Entity entity);
    }
}
