using System;
using DG.Tweening;
using src.Mechanic;
using TMPro;
using UnityEngine;
using Zenject;

namespace src.UIManipulations
{
    public class TotalMoneyChange : MonoBehaviour
    {
        [Inject] private EventHolder _eventHolder;
        [SerializeField] private TMP_Text _moneyText;
        [SerializeField] private int _total;
        private void OnEnable()
        {
            _eventHolder.OnSellMoneyChange += ChangeMoney;
        }

        private void ChangeMoney(Transform sushi)
        {
            if(sushi.TryGetComponent<PriceModel>(out var sushiPrice))
            {
                _total += sushiPrice.Price;
                DOTween.To(() => Int32.Parse(_moneyText.text), (x) => _moneyText.text = x.ToString()+"$", _total, 0.3f);
            }
        }

        public int GetTotalMoney()
        {
            return Int32.Parse(_moneyText.text);
        }
    }
}