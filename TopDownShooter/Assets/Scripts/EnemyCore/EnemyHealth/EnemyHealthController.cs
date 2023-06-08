using System;
using System.Collections;
using EnemyCore.EnemyAttack;
using EnemyCore.EnemyMovement;
using UISystem.HPSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace EnemyCore.EnemyHealth
{
    public class EnemyHealthController : MonoBehaviour
    {
        [SerializeField] private float hp;
        [SerializeField] private float maxhp;
        [SerializeField] private float damageToPatrol;
        [SerializeField] private float damageToSniper;
        [SerializeField] private float damageToFighter;
        [SerializeField] private EnemyHealthBar healthBar;
        public Action<Transform> Explosion;
        public float HP => hp;
        public float MaxHP => maxhp;
        private float _damage;
        
        
       
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.GetComponent<Bullet>())
            {
                healthBar.HealthBar.gameObject.SetActive(true);
                if (GetComponent<EnemyStaticRotate>())
                {
                TakeDamage(damageToPatrol);
                
                
                    
                }
                else if (GetComponent<MeleeAttack>())
                {
                    TakeDamage(damageToFighter);
                    
                    
                    
                }
                else if (gameObject.layer == 7)
                {
                    TakeDamage(damageToSniper);
                    
                    
                    
                }
            }
           
               
        }
   
       
   
        private void TakeDamage(float damageType)
        {
            if (hp > 0)
            {
                StartCoroutine(ChangeColor());
                hp-= damageType;
                if (hp < 0)
                    hp = 0;
                   
            }
            healthBar.UpdateHealthBar();
            if(hp == 0)
            {
                Explosion?.Invoke(gameObject.transform);
                gameObject.SetActive(false);
                
            }
                   
        }
   
        IEnumerator ChangeColor()
        {
            GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            GetComponent<Renderer>().material.color = Color.white;
   
        }
    }
}

