using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;
    private int i;
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (Input.GetKey(KeyCode.E) && i == _enemies.Length )
        {
            SceneManager.LoadScene(2);
        }
    }

    private void Update()
    {
       
            if (!_enemies[i].activeSelf)
            {
                i++;

            }
            
        
        Debug.Log(i);
    }

    private void Start()
    {
        i = 0;
    }
}
