using System;
using System.Collections;
using System.Collections.Generic;
using EnemyCore.EnemyHealth;
using Unity.VisualScripting;
using UnityEngine;

public class ArenaScore : MonoBehaviour
{
    private EnemyHealthController _enemyHealthController;
    public Action<int> Score;
    private int _scoreCount;
    void Start()
    {
        _enemyHealthController = GetComponent<EnemyHealthController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyHealthController.HP <= 0)
        {
            _scoreCount++;
            Score?.Invoke(_scoreCount);
            
            
        }
        
    }
}
