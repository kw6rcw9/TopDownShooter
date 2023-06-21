using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ArenaView : MonoBehaviour
{
    [SerializeField] private ArenaSpawn _arenaSpawn;
    [SerializeField] private Text _text;
    private int _scoreCount;

    public int ScoreCount
    {
        get => _scoreCount;
        set { _scoreCount = value; }
    }
    [CanBeNull] public List<GameObject> _enemies;


 
    
    public void Scoring ()
    {
        _text.text = "Score: " + _scoreCount;

    }

   
    public void Removing()
    {
        if (_enemies.Count > 0)
        {
            for (int i = 0; i < _enemies.Count; i++)
            {



                if (!_enemies[i].activeSelf)
                {
                    _enemies.Remove(_enemies[i]);

                }
            }


        }
        
    }
}
