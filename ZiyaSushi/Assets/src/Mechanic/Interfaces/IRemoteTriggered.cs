using UnityEngine;

namespace src.Mechanic.Interfaces
{
    public interface IRemoteTriggered
    {
        public void OnRemoteTriggerEnter(Collider other, GameObject from);
    }
}