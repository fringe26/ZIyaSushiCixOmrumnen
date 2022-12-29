using System;
using DG.Tweening;
using UnityEngine;

namespace src.DoTweenAnimations
{
    public class ChocolateAnimation : MonoBehaviour
    {
        private void Start()
        {
            transform.DOLocalRotate(Vector3.forward * 6, 2f).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
