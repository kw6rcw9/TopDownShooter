using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGun : MonoBehaviour
{
  [SerializeField] private Transform _firePoint;
  [SerializeField] private GameObject _gun;
  
  private void OnTriggerStay2D(Collider2D col)
  {
    if (Input.GetKey(KeyCode.E))
    {
      gameObject.SetActive(false);
      _gun = Instantiate(_gun, _firePoint.position, _firePoint.rotation, col.transform );

    }
  }
}
