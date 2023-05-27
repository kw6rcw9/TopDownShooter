using UnityEngine;

namespace EnemyCore
{
    public class RangePlayerDetect : ADetectController
    {
        

      
       
        
        
       


        public override void FieldOfViewCheck(float radius, float angle, LayerMask targetMask, LayerMask obsMask)
        {
            Collider2D rangeCheck = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), radius, targetMask);

            if (rangeCheck != null)
            {
                Transform target = rangeCheck.transform;
                Vector2 directionToTarget = (target.position - transform.position).normalized;

                if (Vector2.Angle(transform.up, directionToTarget) < angle / 2)
                {
                    float distanceToTarget = Vector2.Distance(transform.position, target.position);

                    if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obsMask))
                        SeePlayer(true, target.gameObject);
                    else
                        SeePlayer(false);
                }
                else
                    SeePlayer(false);

            }
            else if (_canSeePlayer)
            {
                SeePlayer(false);
            }
        }
       
        

       
    }
}
