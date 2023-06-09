using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _firePoint;
    public Action<int> AmmoView;
     [SerializeField] private int ammoCount;
    public int AmmoCount
    {
        get => ammoCount;
        set { ammoCount = value;  }
    }

   

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            AmmoView?.Invoke(ammoCount);
            if (Input.GetMouseButtonDown(0) && ammoCount > 0)
            {
                
                ShootBullet(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                ammoCount--;
                AmmoView?.Invoke(ammoCount);
                
                
                
            }

            if (ammoCount == 0)
            {
                if(!GetComponent<Reloading>())
                    gameObject.AddComponent<Reloading>();

            }
                
            
            
                 
            
            
        }
    }
    public void ShootBullet(Vector2 dir)
    {
        Bullet bullet = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
    }

    void Reload()
    {
        
        ammoCount = 10;
        AmmoView?.Invoke(ammoCount);


    }
}
