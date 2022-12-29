using System;
using System.Collections.Generic;
using DG.Tweening;
using src.Mechanic;
using UnityEngine;
using Zenject;

namespace src.FinishBehavior
{
    public class SushiToDishes : MonoBehaviour
    {
        [Inject] private EventHolder _eventHolder;
        [Inject] private StackHolder _stackHolder;
        public int count = 0;
        [SerializeField] private List<Transform> _dishesTransform;
        private void Start()
        {
            _eventHolder.OnFinishArrive += SushiToDish;
        }

        private void SushiToDish(GameObject sushi)
        {
            if (count < _dishesTransform.Count)
            {
                sushi.transform.parent = _dishesTransform[count];
                _stackHolder.SushiStack.Remove(sushi.transform);
                sushi.transform.DOLocalJump(Vector3.zero, 2f, 1, 0.5f);
                count++;
                
            }
            
        }
    }
}
