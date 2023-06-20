using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _firePoint;
    public Action<int,int> AmmoView;
     [FormerlySerializedAs("ammoCount")] [SerializeField] private int _ammoCount;
     [FormerlySerializedAs("ammoCage")] [SerializeField] private int _ammoCage;
    public int AmmoCount
    {
        get => _ammoCount;
        set { _ammoCount = value;  }
    }
    public int AmmoCage
    {
        get => _ammoCage;
        set { _ammoCage = value;  }
    }


   

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            PlayerPrefs.SetInt("AmmoCount", AmmoCount);
            PlayerPrefs.SetInt("AmmoCage", AmmoCage);
            PlayerPrefs.Save();
            
            AmmoView?.Invoke(_ammoCount,_ammoCage);
            if (Input.GetMouseButtonDown(0) && _ammoCount > 0)
            {
                
                ShootBullet(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                _ammoCount--;
                AmmoView?.Invoke(_ammoCount,_ammoCage);
                
                
                
            }

            if (_ammoCount == 0)
            {
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    if(!GetComponent<ArenaReloading>())
                        gameObject.AddComponent<ArenaReloading>();
                    
                }
                else
                {
                    if(!GetComponent<Reloading>())
                        gameObject.AddComponent<Reloading>();
                    
                }

            }
                
            
            
                 
            
            
        }
    }
    public void ShootBullet(Vector2 dir)
    {
        Bullet bullet = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
    }

    
}
