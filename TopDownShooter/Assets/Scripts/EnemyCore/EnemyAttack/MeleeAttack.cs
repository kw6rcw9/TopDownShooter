using UnityEngine;

namespace EnemyCore.EnemyAttack
{
    public class MeleeAttack : MonoBehaviour
    {
        [SerializeField] private PlayerDetector _playerDetect;
        

     


 

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.transform == _playerDetect.Player.transform)
            {
                _playerDetect.Player.GetComponent<Renderer>().material.color = Color.red;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.transform == _playerDetect.Player.transform)
            {
                _playerDetect.Player.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}
