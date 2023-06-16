using System;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyCore.EnemyMovement
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private float _speed;
         private PlayerDetector _playerDetector;
         private Rigidbody2D _rigidbody2D;
         private Vector2 _moveTo;
         private float _time;
         private bool _isDetected;
         public bool IsDetected => _isDetected;
        
    

        private void Start()
        {
            _isDetected = false;
            _playerDetector = GetComponent<PlayerDetector>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Detection();
        }

        private void FixedUpdate()
        {
            if (_isDetected)
            {
                MoveToPlayer();
                
            }
           
        }

        private void Detection()
        {
            if (_playerDetector.Player)
                _isDetected = true;


        }
       
        private void MoveToPlayer()
        {
            _moveTo = (_player.transform.position - _rigidbody2D.transform.position).normalized;
            _rigidbody2D.MovePosition(_rigidbody2D.position + _moveTo * _speed * Time.fixedDeltaTime);
        }

        

        

        
    }
}
