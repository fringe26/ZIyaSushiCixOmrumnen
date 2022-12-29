using System;
using DG.Tweening;
using UnityEngine;

namespace src.DoTweenAnimations
{
    public class IceCreamAnimation : MonoBehaviour
    {
        private void Start()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(new Vector3(1, 1, 1), 0.7f);
        }
    }
}
