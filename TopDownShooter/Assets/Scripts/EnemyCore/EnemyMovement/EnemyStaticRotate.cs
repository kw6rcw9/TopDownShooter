using UnityEngine;

namespace EnemyCore.EnemyMovement
{
    public class EnemyStaticRotate : MonoBehaviour
    {
        [SerializeField]  private float _start;
        [SerializeField] private float _end;
        private PlayerDetector _playerDetector;
        private EnemyRotator _rotator;
        private bool left;
        private bool right;
        private Quaternion q1;
        private Quaternion q2;

        void Start()
        {
         
             q1 = Quaternion.Euler(0, 0, _end);
             q2 = Quaternion.Euler(0, 0, _start);
            _playerDetector = GetComponent<PlayerDetector>();
            _rotator = GetComponent<EnemyRotator>();
            left = true;
            right = false;



        }


        void Update()
        {
            if (_playerDetector.Player != null)
            {
                _rotator.enabled = true;
                GetComponent<EnemyStaticRotate>().enabled = false;
            }
            if (left == true)
            {
                RotateRight();
                if (transform.rotation == q1)
                {
                    left = false;
                    right = true;
                }
            }

            if (right == true)
            {
                RotateLeft();
                if (transform.rotation == q2)
                {
                    right = false;
                    left = true;
                }
            }



        }

        private void RotateRight()
        {
            transform.rotation =
                Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, _end), 4f * Time.deltaTime);

        }

        private void RotateLeft()
        {
            transform.rotation =
                Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, _start), 4f * Time.deltaTime);

        }
    }
}
