using UnityEngine;

namespace EnemyCore.EnemyMovement
{
    public class EnemyRotator : MonoBehaviour
    {
        private MeelePlayerDetect _playerDetector;
        private Rigidbody2D _rigidbody2D;
        private Vector3 _direction;
        private Vector3 _lookAt;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerDetector = GetComponent<MeelePlayerDetect>();

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
