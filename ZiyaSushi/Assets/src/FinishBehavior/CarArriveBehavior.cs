using System;
using System.Collections.Generic;
using DG.Tweening;
using src.Mechanic;
using UnityEngine;
using Zenject;

namespace src.FinishBehavior
{
    public class CarArriveBehavior:MonoBehaviour
    {
        private EventHolder _eventHolder;
        private StackHolder _stackHolder;
        [SerializeField] private Transform _firstHoldTransform;
        [SerializeField] private Transform _secondHoldTransform;
        [SerializeField] private Transform _thirdHoldTransform;
        [SerializeField] private Transform _firstPackageTransform;
        [SerializeField] private Transform _secondPackageTransform;
        [SerializeField] private Transform _thirdPackageTransform;
        [SerializeField] private List<Transform> _packages;
        
        private float _offSet=0;
        private float _offSetZ = 0;
        private int sushiInPackage = 0;
        
        [Inject]
        private void Construct(EventHolder eventHolder, StackHolder stackHolder)
        {
            _eventHolder = eventHolder;
            _stackHolder = stackHolder;
        }

        private void OnEnable()
        {
            _eventHolder.OnLastFinishArrive += MoveIceCreamToCar;
        }

        private void Start()
        {
            _packages.Add(_firstHoldTransform);
            _packages.Add(_secondHoldTransform);
            _packages.Add(_thirdHoldTransform);
        }

        private void MoveIceCreamToCar(GameObject sushi)
        {
            if (sushiInPackage < 4)
            {
                Transform _holdTransform = _packages[0];
                _stackHolder.SushiStack.Remove(sushi.transform);
                var seq = DOTween.Sequence();
                sushi.transform.parent = _holdTransform;
                seq.Append(sushi.transform.DOLocalJump(new Vector3(0+_offSet, 0, 0+_offSetZ), 3f, 1, 0.3f))
                    .Insert(0.1f, sushi.transform.DOScale(1f, 0.2f))
                    .AppendCallback(() =>
                    {   
                        
                        seq.Kill();
                    });
                _offSet += 3f;
                if (sushiInPackage == 1)
                {
                    _offSetZ += 3f;
                    _offSet = 0;
                }

                if (sushiInPackage == 3)
                {
                    _offSet = 0;
                    _offSetZ = 0;
                    _firstPackageTransform.DORotate(new Vector3(-90, 0, 0), 1.5f);
                }

                sushiInPackage++;
            }
            else if (sushiInPackage >= 4 && sushiInPackage <= 8)
            {
                Transform _holdTransform = _packages[1];
                _stackHolder.SushiStack.Remove(sushi.transform);
                var seq = DOTween.Sequence();
                sushi.transform.parent = _holdTransform;
                seq.Append(sushi.transform.DOLocalJump(new Vector3(0+_offSet, 0, 0+_offSetZ), 3f, 1, 0.3f))
                    .Insert(0.1f, sushi.transform.DOScale(1f, 0.2f))
                    .AppendCallback(() =>
                    {
                        transform.DOScale(1f, 0.1f);
                        seq.Kill();
                    });
                _offSet += 3f;
                if (sushiInPackage == 5)
                {
                    _offSetZ += 3f;
                    _offSet = 0;
                }
                
                if (sushiInPackage == 7)
                {
                    _offSet = 0;
                    _offSetZ = 0;
                    _secondPackageTransform.DORotate(new Vector3(-90, 0, 0), 1.5f);
                }

                sushiInPackage++;
            }
            else if (sushiInPackage > 8 && sushiInPackage <= 12)
            {
                Transform _holdTransform = _packages[2];
                _stackHolder.SushiStack.Remove(sushi.transform);
                var seq = DOTween.Sequence();
                sushi.transform.parent = _holdTransform;
                seq.Append(sushi.transform.DOLocalJump(new Vector3(0+_offSet, 0, 0+_offSetZ), 3f, 1, 0.3f))
                    .Insert(0.1f, sushi.transform.DOScale(1f, 0.2f))
                    .AppendCallback(() =>
                    {
                        seq.Kill();
                    });
                _offSet += 3f;
                if (sushiInPackage == 9)
                {
                    _offSetZ += 3f;
                    _offSet = 0;
                }
                
                if (sushiInPackage == 11)
                {
                    _offSet = 0;
                    _offSetZ = 0;
                    _thirdPackageTransform.DORotate(new Vector3(-90, 0, 0), 1.5f);
                }

                sushiInPackage++;
            }
           
        }
    }
}