using System.Collections;
using EnemyCore.EnemyAttack;
using EnemyCore.EnemyMovement;
using UISystem.HPSystem;
using Unity.VisualScripting;
using UnityEngine;

namespace EnemyCore.EnemyHealth
{
    public class EnemyHealthController : MonoBehaviour
    {
        [SerializeField] private float _hp;
        [SerializeField] private float _Maxhp;
        public float HP => _hp;
        public float MaxHP => _Maxhp;
        [SerializeField] private float damageToPatrol;
        [SerializeField] private float damageToSniper;
        [SerializeField] private float damageToFighter;
        [SerializeField] private EnemyHealthBar _healthBar;
        
        private float _damage;
        private void Update()
        {
            //HpChange?.Invoke();
        }
   
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.GetComponent<Bullet>())
            {
                if (GetComponent<EnemyStaticRotate>())
                {
                TakeDamage(damageToPatrol);
                
                StartCoroutine(ChangeColor());
                    
                }
                else if (GetComponent<MeleeAttack>())
                {
                    TakeDamage(damageToFighter);
                    
                    StartCoroutine(ChangeColor());
                    
                }
                else if (gameObject.layer == 7)
                {
                    TakeDamage(damageToSniper);
                    
                    StartCoroutine(ChangeColor());
                    
                }
            }
           
               
        }
   
       
   
        private void TakeDamage(float damageType)
        {
            if (_hp > 0)
            {
                _hp-= damageType;
                if (_hp < 0)
                    _hp = 0;
                   
            }
            _healthBar.UpdateHealthBar();
            if(_hp == 0)
            {
                Destroy(gameObject);
                
            }
                   
        }
   
        IEnumerator ChangeColor()
        {
            GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(0.3f);
            GetComponent<Renderer>().material.color = Color.white;
   
        }
    }
}

