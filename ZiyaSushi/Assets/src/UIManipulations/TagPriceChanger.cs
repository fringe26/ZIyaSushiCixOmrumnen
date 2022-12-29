using System;
using DG.Tweening;
using src.Mechanic;
using TMPro;
using UnityEngine;
using Zenject;

namespace src.UIManipulations
{
    public class TagPriceChanger : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tagPrice;
        [SerializeField] private int _sum=0;
        [Inject] private StackHolder _stackHolder;
        [Inject] private EventHolder _eventHolder;

        private void OnEnable()
        { 
            _eventHolder.OnTagPriceChange += StartAnimationAgain;
        }
        
        private void StartAnimationAgain()
        {
            foreach (Transform item in _stackHolder.SushiStack)
            {
                if (item!=null && item.TryGetComponent<PriceModel>(out var sushi))
                {
                    _sum += sushi.Price;
                }
            }
            //DOTween.To(() => Int32.Parse(_tagPrice.text), (x) => _tagPrice.text = x.ToString(), _sum, 0.3f);
            _tagPrice.text = $"{_sum}$";
            _sum = 0;
        }

        public int GetTagPrice()
        {
            return Int32.Parse(_tagPrice.text);
        }
    }
}
