using System;
using DG.Tweening;
using src.Mechanic;
using UnityEngine;
using Zenject;

namespace src.FinishBehavior
{
    public class HandsAnimationStart : MonoBehaviour
    {
        private EventHolder _eventHolder;
        private StackHolder _stackHolder;
        [Inject]
        private void Construct(EventHolder eventHolder,StackHolder stackHodler)
        {
            _eventHolder = eventHolder;
            _stackHolder = stackHodler;
        }

      

        private void StartAnimation()
        {
            //_eventHolder.SellMoneyChange(transform);
            transform.DOLocalMoveX(400f, 1.5f);
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Collectable"))
            {
                _eventHolder.OnSellMoneyChange(other.transform);
                StartAnimation();
            }
        }
    }
}
