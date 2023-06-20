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
    public Action<int,int> AmmoView;
     [SerializeField] private int ammoCount;
     [SerializeField] private int ammoCage;
    public int AmmoCount
    {
        get => ammoCount;
        set { ammoCount = value;  }
    }
    public int AmmoCage
    {
        get => ammoCage;
        set { ammoCage = value;  }
    }


   

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            AmmoView?.Invoke(ammoCount,ammoCage);
            if (Input.GetMouseButtonDown(0) && ammoCount > 0)
            {
                
                ShootBullet(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                ammoCount--;
                AmmoView?.Invoke(ammoCount,ammoCage);
                
                
                
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

    
}
