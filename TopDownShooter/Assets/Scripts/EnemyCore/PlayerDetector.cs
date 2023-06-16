using System;
using EnemyCore.EnemyAttack;
using EnemyCore.EnemyMovement;
using UnityEngine;

namespace EnemyCore
{
    public class PlayerDetector : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [Range(0, 360)] [SerializeField] private float _angle;
        [SerializeField] private LayerMask _targetMask;
        [SerializeField] private LayerMask _obstructionMask;
        
        private ADetectController _detectController;
       

        public GameObject Player => _detectController._player;
        void Start()
        {
            if (gameObject.GetComponent<MeleeAttack>())
            {
                _detectController = gameObject.AddComponent<MeelePlayerDetect>();
            }
            else
            {
                _detectController = gameObject.AddComponent<RangePlayerDetect>();
                
            }

            
            
        
        }

        
        void Update()
        {
           
            
            _detectController.FieldOfViewCheck(_radius, _angle, _targetMask, _obstructionMask);
            
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), _radius);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + DirectionFromAngle(-transform.eulerAngles.z, -_angle / 2) * _radius);
            Gizmos.DrawLine(transform.position, transform.position + DirectionFromAngle(-transform.eulerAngles.z, _angle / 2) * _radius);

           
        }
        private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
        {
            angleInDegrees += eulerY;
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }
    }
}
