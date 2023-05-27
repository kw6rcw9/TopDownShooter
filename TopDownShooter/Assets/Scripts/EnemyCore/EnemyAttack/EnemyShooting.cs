using UnityEngine;

namespace EnemyCore.EnemyAttack
{
    public class EnemyShooting : MonoBehaviour
    { 
        private PlayerDetector _playerDetector;
        [SerializeField] EnemyBullet _bullet;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _shootDelay;
        private float _time;

        private void Start()
        {
            _playerDetector = GetComponent<PlayerDetector>();
        
        }

        private void Update()
        {
            if (_playerDetector.Player)
            {
                if (_time < 0)
                {
                    ShootBullet();
                    _time = _shootDelay;
                }
                else
                {
                    _time -= Time.deltaTime;
                }
            }
        }
        public void ShootBullet()
        {
            Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
        }
    }
}
