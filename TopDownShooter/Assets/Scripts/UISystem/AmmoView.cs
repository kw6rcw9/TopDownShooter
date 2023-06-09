using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoView : MonoBehaviour
{
    [SerializeField] private Text ammoText;
    [SerializeField] private Shooting shooting;

    private void OnEnable()
    {
        shooting.AmmoView += AmmoChange;
    }

    private void OnDisable()
    {
        shooting.AmmoView -= AmmoChange;
    }


    void AmmoChange(int ammo)
    {
        ammoText.text = "Ammo: " + ammo;
    }

}
