using System;
using System.Collections;
using System.Collections.Generic;
using src.ParticleManager;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace src.Mechanic
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _horizontal;
        [SerializeField] private float _verticalSpeed;
        [SerializeField] private float _speedMultiplier;
        private EventHolder _eventHolder;
        private StackHolder _stackHolder;
        private int _freezeHorizontal = 1;
        private bool _isFinished = true;

        [Inject]
        public void Construct(EventHolder eventHolder, StackHolder stackHolder)
        {
            _eventHolder = eventHolder;
            _stackHolder = stackHolder;
        }

        private void OnEnable()
        {
            _eventHolder.OnFinishArrive += SlowMovement;
        }

        private void SlowMovement(GameObject obj)
        {
            _speedMultiplier = 4f;
            _verticalSpeed = 4f;
            _freezeHorizontal = 0;
            StartCoroutine(UpSpeed());

        }

        private void StopMove()
        {
            _speedMultiplier = 0f;
            _verticalSpeed = 0f;
            _freezeHorizontal = 0;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("FinishLast"))
            {
                //CameraManager.Instance.SetFollow("PlayerCinemachine", null);
                StopMove();
            }
        }


        private void Start()
        {
            _stackHolder.SushiStack.Add(transform);
        }

        private void FixedUpdate()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _horizontal *= _freezeHorizontal;
            transform.position +=
                new Vector3(_horizontal, 0, _verticalSpeed) * (_speedMultiplier * Time.fixedDeltaTime);
        }

        private void Update()
        {
            if (_stackHolder.SushiStack.Count == 0 && _isFinished)
            {
                CameraManager.instance.OpenCamera("FinalCinemachine",1f,CameraEaseStates.EaseIn);
                StartCoroutine(FinishBoardStarting());
                _isFinished = false;
            }
        }

        private IEnumerator FinishBoardStarting()
        {
            yield return new WaitForSeconds(1.5f);
            _eventHolder.SushiStackGetEmpty();
        }

        private IEnumerator UpSpeed()
        {
            yield return new WaitForSeconds(1f);
            _speedMultiplier = 4.5f;
            _verticalSpeed = 4.5f;
            
        }
    }
}