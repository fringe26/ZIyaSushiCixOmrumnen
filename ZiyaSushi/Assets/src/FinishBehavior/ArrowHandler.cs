using System;
using DG.Tweening;
using src.Mechanic;
using src.UIManipulations;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace src.FinishBehavior
{
    public class ArrowHandler : MonoBehaviour
    {
        [SerializeField] private float _stepAngel;
        [SerializeField] private float _rotateArrow;

        [Inject] private EventHolder _eventHolder;

        /// <summary>
        /// Maybe Change Later to best Practices
        /// </summary>
        private TagPriceChanger _tagPrice;
        private TotalMoneyChange _totalMoney;
        
        private void OnEnable()
        {
            _eventHolder.OnSushiStackEmpty += StartCount;
        }

        private void Start()
        {
            _tagPrice = FindObjectOfType<TagPriceChanger>();
            _totalMoney = FindObjectOfType<TotalMoneyChange>();
        }

        private void StartCount()
        {
            float money = _tagPrice.GetTagPrice() + _totalMoney.GetTotalMoney();
            _stepAngel = 180 / 8.0f;
            if (money - 5 <= 0)
            {
                StartLooseAnimation();
            }
            else
            {
                money = money - 5;
                _rotateArrow += _stepAngel;
                _rotateArrow += (float)(money / 15.0f) * _stepAngel;
                StartWinAnimation();
            }
            
        }

        private void StartWinAnimation()
        {
            float rotateTo = transform.rotation.eulerAngles.z - _rotateArrow+16;
            transform.DOLocalRotate(new Vector3(0, 0, rotateTo), 2f);
            Debug.Log("Animation Started");
        }

        private void StartLooseAnimation()
        {
            throw new NotImplementedException();
        }
    }
}
