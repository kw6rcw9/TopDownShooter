using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDetectedPanel : MonoBehaviour
{
   [SerializeField] private GameObject _panel;
   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.gameObject.layer == 3)
      {
         Time.timeScale = 0;
         _panel.SetActive(true);
         
      }
   }
}
