using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaReloading : MonoBehaviour
{
    private Shooting _ammo;
    private void Awake()
    {
        _ammo = GetComponent<Shooting>();
        Invoke("Reload", 2);
      
    }

    void Reload()
    {
       _ammo.AmmoCount = 10;
        ArenaReloading reloading = GetComponent<ArenaReloading>();
        Destroy(reloading);
         
        
    
      
    }
}
