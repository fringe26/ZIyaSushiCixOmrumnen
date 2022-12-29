using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ChocolateParent : MonoBehaviour
{
    private void Start()
    {
        transform.DORotate(Vector3.up * 90, 4f).SetLoops(-1, LoopType.Incremental);
    }
}