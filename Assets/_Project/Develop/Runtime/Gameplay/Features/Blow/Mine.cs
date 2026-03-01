using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Blow
{
    public class Mine : MonoBehaviour
    {
        [SerializeField] private float _reactionDistance;
        [SerializeField] private int _damage;
        [SerializeField] private ParticleSystem _explodeEffect;

        private CollidersRegistryService _collidersRegistryService;

        private bool _inProcess;

        public void Initialize(CollidersRegistryService collidersRegistryService)
        {
            _collidersRegistryService = collidersRegistryService;
            SphereCollider collider = GetComponent<SphereCollider>();
            collider.radius = _reactionDistance;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_inProcess)
                return;

            if (other.TryGetComponent<MonoEntity>(out MonoEntity entity))
            {
                _inProcess = true;

                _explodeEffect.Play();

                Collider[] colliders = Physics.OverlapSphere(transform.position, _reactionDistance);

                foreach (Collider collider in colliders)
                {
                    Entity contactEntity = _collidersRegistryService.GetBy(collider);

                    if (contactEntity != null)
                    {
                        if (contactEntity.HasComponent<TakeDamageRequest>())
                            contactEntity.TakeDamageRequest.Invoke(_damage);
                    }
                }

                Destroy(gameObject, 1f);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawSphere(transform.position, _reactionDistance);
        }
    }
}
