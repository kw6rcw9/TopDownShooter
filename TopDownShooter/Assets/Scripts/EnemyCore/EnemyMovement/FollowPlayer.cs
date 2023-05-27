using System.Collections.Generic;
using UnityEngine;

namespace EnemyCore.EnemyMovement
{
    public class FollowPlayer : MonoBehaviour
    {
         private PlayerDetector _playerDetector;
         private Rigidbody2D _rigidbody2D;
        
      
        [SerializeField] private float _speed;
        private Vector2 _moveTo;
        private float _time;
        private int _lastPoint;

        private void Start()
        {
            _playerDetector = GetComponent<PlayerDetector>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_playerDetector.Player)
            {
                MoveToPlayer();
                
            }
           
        }

        
        private void MoveToPlayer()
        {
            _moveTo = (_playerDetector.Player.transform.position - _rigidbody2D.transform.position).normalized;
            _rigidbody2D.MovePosition(_rigidbody2D.position + _moveTo * _speed * Time.fixedDeltaTime);
        }

        

        

        
    }
}
