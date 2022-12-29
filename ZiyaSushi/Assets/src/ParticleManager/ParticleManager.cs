using System;
using src.Mechanic;
using UnityEngine;
using Zenject;

namespace src.ParticleManager
{
    public class ParticleManager : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _destroyParticle;

        private EventHolder _eventHolder;

        [Inject]
        private void Construct(EventHolder eventHolder)
        {
            _eventHolder = eventHolder;
        }
        private void OnEnable()
        {
            _eventHolder.OnObstacleCollide += DestroyParticlePlay;
        }

        private void DestroyParticlePlay(GameObject obj)
        {
            if (obj.CompareTag("Player"))
                return;
            _destroyParticle.transform.position = obj.transform.position;
            _destroyParticle.Play();
        }
    }
}
