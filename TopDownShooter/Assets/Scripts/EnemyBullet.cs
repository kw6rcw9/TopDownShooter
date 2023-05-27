using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //[SerializeField] private BlowEffect _blowEffect;
     private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyTime;

    public void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Invoke("DestroyBullet", _destroyTime);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.AddForce(transform.right * _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (!collision.gameObject.GetComponent<Bullet>())
        {
            DestroyBullet();
            
        }
        //ShowEffect();
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    //private void ShowEffect()
    //{
    //    Instantiate(_blowEffect, transform.position, transform.rotation);
    //}
}
