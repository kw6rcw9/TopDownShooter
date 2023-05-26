using UnityEngine;

namespace EnemyCore
{
    public class MeelePlayerDetect : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [Range(0, 360)] [SerializeField] private float _angle;
        [SerializeField] private LayerMask _targetMask;
        [SerializeField] private LayerMask _obstructionMask;

        [SerializeField] private bool _canSeePlayer;
        private GameObject _player;
        public GameObject Player => _player;

        private void Update()
        {
            FieldOfViewCheck();
        }


        private void FieldOfViewCheck()
        {
            Collider2D rangeCheck = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), _radius, _targetMask);

            if (rangeCheck != null)
            {
                Transform target = rangeCheck.transform;
                Vector2 directionToTarget = (target.position - transform.position).normalized;

           
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, _obstructionMask))
                    SeePlayer(true, target.gameObject);
                else
                    SeePlayer(false);
           

            }
            else if (_canSeePlayer)
            {
                SeePlayer(false);
            }
        }

        private void SeePlayer(bool see, GameObject player = null)
        {
            _canSeePlayer = see;
            _player = player;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), _radius);
            Gizmos.color = Color.blue;
       
            if (_canSeePlayer)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, Player.transform.position);
            }
        }
    
    }
}
