using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmmoSave : MonoBehaviour
{
    [SerializeField] private Shooting _shooting;
    void Start()
    {
        
        if (!PlayerPrefs.HasKey("FinalAmmoCount") && !PlayerPrefs.HasKey("FinalAmmoCage"))
        {
            _shooting.AmmoCage = PlayerPrefs.GetInt("AmmoCage");
            _shooting.AmmoCount = PlayerPrefs.GetInt("AmmoCount");
            PlayerPrefs.DeleteKey("AmmoCage");
            PlayerPrefs.DeleteKey("AmmoCount");
            PlayerPrefs.SetInt("FinalAmmoCount", _shooting.AmmoCount);
            PlayerPrefs.SetInt("FinalAmmoCage", _shooting.AmmoCage);
            PlayerPrefs.Save();
            
        }
        else
        {
            _shooting.AmmoCage = PlayerPrefs.GetInt("FinalAmmoCage");
            _shooting.AmmoCount = PlayerPrefs.GetInt("FinalAmmoCount");
            
        }
       


    }

   
}
