using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ArenaView : MonoBehaviour
{
    [SerializeField] private ArenaScore _arenaScore;
    [SerializeField] private Text _text;


    private void OnEnable()
    {
        throw new NotImplementedException();
    }

    private void OnDisable()
    {
        throw new NotImplementedException();
    }
    
    private void Scoring (int scoreCount)
    {
        _text.text = "Score: " + scoreCount;

    }
}
