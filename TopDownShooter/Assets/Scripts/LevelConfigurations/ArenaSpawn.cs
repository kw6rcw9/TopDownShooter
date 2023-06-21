using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ArenaSpawn : MonoBehaviour
{
    [SerializeField] private ArenaView _arenaView;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform[] _points;
    [SerializeField] private Image _canvas;
    private GameObject _enemyy;
    public GameObject Enemy => _enemyy;
    void Start()
    {
        StartCoroutine(Spawn());
        

    }


    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);
        int i = Random.Range(0, 4);
         _enemyy = Instantiate(_enemy, _points[i].position, _enemy.transform.rotation);
         _arenaView._enemies.Add(_enemyy);
         for(int j = 0; j < _arenaView._enemies.Count; j++){
             
            
             if (!_arenaView._enemies[j].activeSelf)
             {
                 _arenaView.ScoreCount++;
                 _arenaView.Scoring();

             }
                 _arenaView.Removing();
                 
            
         }
         
        StartCoroutine(Spawn());

    }
}
