using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{

    [SerializeField] private GameObject _panel;
    
    [SerializeField] private GameObject[] _enemies;
    private int _sceneInd;
    private int i;
    private void Update()
    {
        
        if (i != _enemies.Length)
        {
            if (!_enemies[i].activeSelf)
            { 
                i++;

            }
        } 
        if ( i == _enemies.Length )
        {
            PlayerPrefs.SetInt("LevelComplete", _sceneInd);
            _panel.gameObject.SetActive(true);
            Time.timeScale = 0;
            
        }
        
        
    }

    private void Start()
    {
        _sceneInd = SceneManager.GetActiveScene().buildIndex;
        i = 0;
    }
    
   
}
