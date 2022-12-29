using System;
using DG.Tweening;
using UnityEngine;

namespace src.DoTweenAnimations
{
    public class ObstacleLong : MonoBehaviour
    {
        private void Start()
        {
            transform.DOMoveX(0.6f, 0.8f).SetLoops(-1,LoopType.Yoyo);
            transform.DORotate(Vector3.forward * 90, 0.1f).SetLoops(-1, LoopType.Incremental);
        }
    }
}
