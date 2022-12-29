using src.Mechanic.Interfaces;
using UnityEngine;

namespace src.Mechanic
{
    [RequireComponent(typeof(Rigidbody))]
    public class CollectedSushi : MonoBehaviour
    {
        
        [SerializeField] private Rigidbody thisRigidbody;
        private IRemoteTriggered _remoteTriggered;
        
        public bool IsCollected { get; private set; }

        public bool IsKinematic
        {
            get => thisRigidbody.isKinematic;
            set => thisRigidbody.isKinematic = value;
        }

        public void InitializeOnCollect(IRemoteTriggered remoteTriggered)
        {
            _remoteTriggered = remoteTriggered;
            IsCollected = true;
        }

        public void DeInitializeOnDropped()
        {
            _remoteTriggered = null;
            IsCollected = false;
        }

        private void Reset()
        {
            thisRigidbody ??= GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _remoteTriggered?.OnRemoteTriggerEnter(other, gameObject);
        }
    }
}