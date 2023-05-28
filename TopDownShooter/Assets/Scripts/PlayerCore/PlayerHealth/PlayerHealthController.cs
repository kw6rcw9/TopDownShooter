using System;
using System.Collections;
using Bullets;
using EnemyCore.EnemyAttack;
using UISystem.HPSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerCore.PlayerHealth
{
    public class PlayerHealthController : MonoBehaviour
    {
        [SerializeField] private float _hp;
        [SerializeField] private float _Maxhp;
        public float HP => _hp;
        public float MaxHP => _Maxhp;
        [SerializeField] private float damageFromPetrol;
        [SerializeField] private float damageFromSniper;
        [SerializeField] private float damageFromFighter;
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
                TakeDamage(damageFromPetrol);
                StartCoroutine(ChangeColor());
            }
            else if (col.gameObject.GetComponent<SniperBullet>())
            {
                TakeDamage(damageFromSniper);
                StartCoroutine(ChangeColor());
            }
            
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
             if (col.gameObject.GetComponent<MeleeAttack>())
            {
                TakeDamage(damageFromFighter);
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
