using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace EnemyCore.EnemyMovement
{
    public class EnemyRotator : MonoBehaviour
    {
        private PlayerDetector _playerDetector;
        private Rigidbody2D _rigidbody2D;
        private Vector3 _direction;
        private Vector3 _lookAt;
        private FollowPlayer _followPlayer;
        

        private void Start()
        {
            _followPlayer = GetComponent<FollowPlayer>();
            if (!GetComponent<Rigidbody2D>())
            {
             gameObject.AddComponent<Rigidbody2D>();
             _followPlayer.enabled = true;


            }
             _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.gravityScale = 0;
            _rigidbody2D.mass = 10;
            _rigidbody2D.freezeRotation = true;
            _playerDetector = GetComponent<PlayerDetector>();
            
           

        }

        void Update()
        {
            if (_playerDetector.Player != null)
            {
               
                
                _lookAt = _playerDetector.Player.transform.position;
                _direction = _lookAt - transform.position;
                _direction.Normalize();
                LookAtPoint();
            }

            
        }
        private void LookAtPoint()
        {
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg - 90;
            _rigidbody2D.rotation = angle;
        }
    }
}
