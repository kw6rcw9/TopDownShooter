using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;
    private int i;
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<PlayerMovement>())
        {
            if (Input.GetKey(KeyCode.E) && i == _enemies.Length )
            {
                SceneManager.LoadScene(2);
            }
            
        }
        
    }

    private void Update()
    {
        if (i != _enemies.Length)
        {
            if (!_enemies[i].activeSelf)
            { 
                i++;

            }
        } 
        
        
    }

    private void Start()
    {
        i = 0;
    }
}
