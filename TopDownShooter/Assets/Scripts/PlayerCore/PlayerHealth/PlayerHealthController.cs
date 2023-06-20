using System;
using System.Collections;
using Bullets;
using EnemyCore.EnemyAttack;
using UISystem.HPSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace PlayerCore.PlayerHealth
{
    public class PlayerHealthController : MonoBehaviour
    {
        [SerializeField] private float _hp;
        [SerializeField] private float _Maxhp;

        public float HP
        {
            get => _hp;
            set { _hp = value;  }
        }
        public float MaxHP => _Maxhp;
        [FormerlySerializedAs("damageFromPetrol")] [SerializeField] private float _damageFromPetrol;
        [FormerlySerializedAs("damageFromSniper")] [SerializeField] private float _damageFromSniper;
        [FormerlySerializedAs("damageFromFighter")] [SerializeField] private float _damageFromFighter;
        [SerializeField] private PlayerHealthBar _healthBar;
        public Action <int> HpChange;
        private float _damage;
        private void Update()
        {
            //HpChange?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.GetComponent<EnemyBullet>())
            {
                TakeDamage(_damageFromPetrol);
                StartCoroutine(ChangeColor());
            }
            else if (col.gameObject.GetComponent<SniperBullet>())
            {
                TakeDamage(_damageFromSniper);
                StartCoroutine(ChangeColor());
            }
            
        }

        private void OnCollisionExit2D(Collision2D col)
        {
             if (col.gameObject.GetComponent<MeleeAttack>())
             {

                 
                StartCoroutine(ChangeColor());
            }
        }
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.GetComponent<MeleeAttack>())
            {

                TakeDamage(_damageFromFighter);
                StartCoroutine(ChangeColor());
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
            
        }

        IEnumerator ChangeColor()
        {
            GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(0.3f);
            GetComponent<Renderer>().material.color = Color.white;

        }

        
    }
}
