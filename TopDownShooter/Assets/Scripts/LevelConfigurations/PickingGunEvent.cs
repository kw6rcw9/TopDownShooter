using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickingGunEvent : MonoBehaviour
{
  [SerializeField] private Transform _firePoint;
  [SerializeField] private GameObject _gun;
  [SerializeField] private Canvas _health;
  [SerializeField] private Text _ammo;
  [SerializeField] private GameObject _player;
  
  private void OnTriggerStay2D(Collider2D col)
  {
    if (Input.GetKey(KeyCode.E))
    {
      gameObject.SetActive(false);
      _gun = Instantiate(_gun, _firePoint.position, _firePoint.rotation, col.transform );
      _health.gameObject.SetActive(true);
      _ammo.gameObject.SetActive(true);
      _player.GetComponent<Shooting>().enabled = true;
    }
  }
}
