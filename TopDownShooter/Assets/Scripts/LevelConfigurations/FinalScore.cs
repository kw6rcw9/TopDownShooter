using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Text _text;
    [SerializeField] private ArenaView _arenaView;
    
    void Update()
    {
        if (_panel.activeSelf)
        {
            _text.text = "You`re score: " + _arenaView.ScoreCount;

        }
        
    }
}
