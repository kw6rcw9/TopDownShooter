using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsSave : MonoBehaviour
{
    [SerializeField] private Button _firstLevel;
    [SerializeField] private Button _secondLevel;
    [SerializeField] private Button _infiniteLevel;
    private int levelComplete;
    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        _secondLevel.interactable = false;
        _infiniteLevel.interactable = false;
        switch (levelComplete)
        {
            case 1:
                _secondLevel.interactable = true;
                break;
            case 2:
                _secondLevel.interactable = true;
                _infiniteLevel.interactable = true;
                break;
            
        }


    }

    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }


    public void Reset()
    {
        _secondLevel.interactable = false;
        _infiniteLevel.interactable = false;
        PlayerPrefs.DeleteKey("LevelComplete");
    }
    void Update()
    {
        
    }
}
