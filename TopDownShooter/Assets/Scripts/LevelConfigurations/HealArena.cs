using System.Collections;
using System.Collections.Generic;
using PlayerCore.PlayerHealth;
using UISystem.HPSystem;
using UnityEngine;

public class HealArena : MonoBehaviour
{
    [SerializeField] private PlayerHealthController _playerHealthController;
    [SerializeField] private PlayerHealthBar _healthBar;
    
        
    void Start()
    {
        
        StartCoroutine(Healing());

    }

    IEnumerator Healing()
    {
        yield return new WaitForSeconds(15f);
        _playerHealthController.HP = _playerHealthController.MaxHP;
        _healthBar.UpdateHealthBar();

        StartCoroutine(Healing());


    }
}
