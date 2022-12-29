using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using src.Mechanic;
using UnityEngine;
using Zenject;

public class StartArrowAnimation : MonoBehaviour
{
   [Inject] private EventHolder _eventHolder;

   private void OnEnable()
   {
      _eventHolder.OnSushiStackEmpty += StartAnimation;
   }

   private void StartAnimation()
   {
      transform.DOLocalMoveY(40f, 2f);
   }
}
