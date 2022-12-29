using DG.Tweening;
using src.Mechanic.Interfaces;
using src.ParticleManager;
using UnityEngine;
using Zenject;


namespace src.Mechanic
{
    public class SushiCollector : MonoBehaviour, IRemoteTriggered
    {
        private EventHolder _eventHolder;
        private StackHolder _collectedSushi;
        [SerializeField] private float _offsetZ;
        [SerializeField] private float _lerpSpeed;
        private Sequence seq;

        [Inject]
        public void Construct(EventHolder eventHolder, StackHolder collectedSushi)
        {
            _eventHolder = eventHolder;
            _collectedSushi = collectedSushi;
        }

        private void OnEnable()
        {
            _eventHolder.OnSushiCollect += ChangeSushiState;
        }

        private void FixedUpdate()
        {
            if (_collectedSushi.SushiStack.Count > 1)
            {
                FollowSushi();
            }
        }

        private void FollowSushi()
        {
            for (var i = 1; i < _collectedSushi.SushiStack.Count; i++)
            {
                var prePos = _collectedSushi.SushiStack[i - 1].position + Vector3.forward * _offsetZ;
                var curPos = _collectedSushi.SushiStack[i].position;
                _collectedSushi.SushiStack[i].position = Vector3.Lerp(curPos, prePos, _lerpSpeed * Time.deltaTime);
            }
        }


        private void ChangeSushiState(CollectedSushi sushi)
        {
            sushi.InitializeOnCollect(this);
            sushi.IsKinematic = true;
            var sushiTransform = sushi.transform;
            sushiTransform.parent = null;
            _collectedSushi.SushiStack.Add(sushiTransform);
            _eventHolder.TagPriceChangeEvent();
            if (sushiTransform != null)
            {
                AnimationStart();

            }
            
        }

        private void AnimationStart()
        {
            seq = DOTween.Sequence();
            seq.Kill();
            seq = DOTween.Sequence();
            for (int i = _collectedSushi.SushiStack.Count - 1; i >= 0; i--)
            {
                seq.WaitForCompletion(true);
                seq.Join(_collectedSushi.SushiStack[i].DOScale(1.5f, 0.2f));
                seq.AppendInterval(0.05f);
                seq.Join(_collectedSushi.SushiStack[i].DOScale(1f, 0.2f));
            }
            seq.Kill();
            
        }

        private void OnTriggerEnter(Collider other)
        {
            OnRemoteTriggerEnter(other, gameObject);
        }

        public void OnRemoteTriggerEnter(Collider other, GameObject from)
        {
            if (other.TryGetComponent<CollectedSushi>(out var sushi) && !sushi.IsCollected)
            {
                _eventHolder.SushiCollectEvent(sushi);
                
            }

            if (other.CompareTag("Obstacle"))
            {
                if (from.TryGetComponent<CollectedSushi>(out var collidedSushi))
                {
                    if (collidedSushi.IsCollected)
                    {
                        _eventHolder.ObstacleCollidedEvent(from);
                        
                    }

                }
            }

            if (other.CompareTag("SoyaGate"))
            {
                _eventHolder.SoyaAdd(from);
            }
            
            if (other.CompareTag("SalmonGate"))
            {
                _eventHolder.SalmonAdd(from);
            }
            
            if (other.CompareTag("WasabiGate"))
            {
                _eventHolder.WasabiAdd(from);
            }

            if (other.CompareTag("FinishLine"))
            {
                _eventHolder.FinishArrivedEvent(from);
                CameraManager.instance.OpenCamera("HandsCamera");
            }

            if (other.CompareTag("FinishLast"))
            {
                _eventHolder.CarArriveEvent(from);
                CameraManager.instance.OpenCamera("PackageCamera",1f,CameraEaseStates.EaseIn);
            }
        }
    }
}