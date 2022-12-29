using DG.Tweening;
using UnityEngine;

namespace src.DoTweenAnimations
{
    public class ObstacleShort : MonoBehaviour
    {
        private void Start()
        {
            //transform.DOMoveX(0.330f, 0.8f).SetLoops(-1,LoopType.Yoyo);
            transform.DORotate(Vector3.back * 90, 0.5f).SetLoops(-1, LoopType.Incremental);
        }
    }
}
