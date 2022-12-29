using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace src.Mechanic
{
     public class SushiEraser : MonoBehaviour
    {
        private EventHolder _eventHolder;
        private StackHolder _stackHolder;

        [Inject]
        private void Construct(EventHolder eventHolder, StackHolder stackHolder)
        {
            _eventHolder = eventHolder;
            _stackHolder = stackHolder;
        }

        private void OnEnable()
        {
            _eventHolder.OnObstacleCollide += RemoveFromList;
        }

        private void RemoveFromList(GameObject sushi)
        {
            var startIndex = _stackHolder.SushiStack.IndexOf(sushi.transform);
            if (startIndex <= -1) return;
            startIndex = Mathf.Clamp(startIndex, 1, startIndex);
            var endIndex = _stackHolder.SushiStack.Count - startIndex - 1;
            endIndex = Mathf.Clamp(endIndex, 0, endIndex);
            var droppedSushi = _stackHolder.SushiStack.GetRange(startIndex, endIndex);

            

            HandleDeletedSushi(ref droppedSushi);
            _stackHolder.SushiStack.RemoveRange(startIndex, endIndex);
            
            if (!sushi.CompareTag("Player"))
            {
                var collidedSushi = _stackHolder.SushiStack[startIndex];
                if (collidedSushi.TryGetComponent<CollectedSushi>(out var collectedSushi))
                {
                    collectedSushi.DeInitializeOnDropped();
                    _stackHolder.SushiStack.Remove(collidedSushi);
                    collidedSushi.transform.DOKill(true);
                    Destroy(collidedSushi.gameObject);
                }
            }
            
            _eventHolder.TagPriceChangeEvent();
        }

        private void HandleDeletedSushi(ref List<Transform> droppedSushi)
        {
            //var seq = DOTween.Sequence();
            
            foreach (var sushi in droppedSushi)
            {
                if (!sushi.TryGetComponent<CollectedSushi>(out var collectedSushi)) continue;
                collectedSushi.DeInitializeOnDropped();
                var currentPos = sushi.transform.position;
                collectedSushi.transform.DOJump(
                    new Vector3(currentPos.x + Random.Range(-10f, 10f), 1,
                        currentPos.z + Random.Range(30,35)), 2f, 1, 0.5f);
                
            }
        }
    }
}

