using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance = null;
    private int _sceneInd;
    private int _levelComplete;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        _sceneInd = SceneManager.GetActiveScene().buildIndex;
        _levelComplete = PlayerPrefs.GetInt("LevelComplete");

    }

    public void IsEndGame()
    {
        if (_sceneInd == 3)
        {
            Invoke("LoadMainMenu", 1f);
        }
        else
        {
            if (_levelComplete < _sceneInd)
                PlayerPrefs.SetInt("LevelComplete", _sceneInd);
            SceneManager.LoadScene(_sceneInd + 1);
                
            
        }
    }

    

    void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
