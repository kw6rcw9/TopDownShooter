using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _enemies;
    private int i;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            _enemies.SetActive(true);
            
            
        }
    }
}
