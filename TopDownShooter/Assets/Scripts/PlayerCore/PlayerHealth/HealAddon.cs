using System;
using System.Collections;
using System.Collections.Generic;
using PlayerCore.PlayerHealth;
using UISystem.HPSystem;
using UnityEngine;

public class HealAddon : MonoBehaviour
{
    [SerializeField] private PlayerHealthController _playerHealthController;
    [SerializeField] private PlayerHealthBar _healthBar;

    private void OnTriggerEnter2D(Collider2D col)
    {
        _playerHealthController.HP = _playerHealthController.MaxHP;
        _healthBar.UpdateHealthBar();
        gameObject.SetActive(false);
        
    }
}
