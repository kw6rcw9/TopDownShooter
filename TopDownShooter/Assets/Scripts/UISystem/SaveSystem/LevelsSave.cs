using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsSave : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Text _text;
    [SerializeField] private Button _firstLevel;
    [SerializeField] private Button _secondLevel;
    [SerializeField] private Button _infiniteLevel;
    private int levelComplete;
    void Update()
    {
        
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        _secondLevel.interactable = false;
        _infiniteLevel.interactable = false;
        switch (levelComplete)
        {
            case 0:
                _text.text = "Play";
                break;
            case 1:
                _text.text = "Continue";
                _playButton.onClick.RemoveAllListeners();
                _playButton.onClick.AddListener(Load);
                _secondLevel.interactable = true;
                break;
            case 2:
                _playButton.onClick.RemoveAllListeners();
                _playButton.onClick.AddListener(Load);
                _secondLevel.interactable = true;
                _infiniteLevel.interactable = true;
                break;
            
        }


    }

    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Load()
    {
        SceneManager.LoadScene(2);
        
    }


    public void Reset()
    {
        _secondLevel.interactable = false;
        _infiniteLevel.interactable = false;
        PlayerPrefs.DeleteKey("LevelComplete");
        PlayerPrefs.DeleteKey("FinalAmmoCage");
        PlayerPrefs.DeleteKey("FinalAmmoCount");
        levelComplete = 0;
    }
    
}
