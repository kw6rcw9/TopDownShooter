using System;
using System.Collections;
using EnemyCore.EnemyAttack;
using EnemyCore.EnemyMovement;
using UISystem.HPSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace EnemyCore.EnemyHealth
{
    public class EnemyHealthController : MonoBehaviour
    {
        [FormerlySerializedAs("hp")] [SerializeField] private float _hp;
        [FormerlySerializedAs("maxhp")] [SerializeField] private float _maxhp;
        [FormerlySerializedAs("damageToPatrol")] [SerializeField] private float _damageToPatrol;
        [FormerlySerializedAs("damageToSniper")] [SerializeField] private float _damageToSniper;
        [FormerlySerializedAs("damageToFighter")] [SerializeField] private float _damageToFighter;
        [FormerlySerializedAs("healthBar")] [SerializeField] private EnemyHealthBar _healthBar;
        public Action<Transform> Explosion;
        
        public float HP
        {
            get => _hp; 
            
        }

        public float MaxHP => _maxhp;
        private float _damage;


        

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.GetComponent<Bullet>())
            {
                _healthBar.HealthBar.gameObject.SetActive(true);
                if (GetComponent<EnemyStaticRotate>())
                {
                TakeDamage(_damageToPatrol);
                
                
                    
                }
                else if (GetComponent<MeleeAttack>())
                {
                    TakeDamage(_damageToFighter);
                    
                    
                    
                }
                else if (gameObject.layer == 7)
                {
                    TakeDamage(_damageToSniper);
                    
                    
                    
                }
            }
           
               
        }
   
       
   
        private void TakeDamage(float damageType)
        {
            if (_hp > 0)
            {
                StartCoroutine(ChangeColor());
                _hp-= damageType;
                if (_hp < 0)
                    _hp = 0;
                   
            }
            _healthBar.UpdateHealthBar();
            if(_hp == 0)
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

