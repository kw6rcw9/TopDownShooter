using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform[] _points;
    [SerializeField] private Image _canvas;
    void Start()
    {
        StartCoroutine(Spawn());

    }


    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);
        int i = Random.Range(0, 3);
        GameObject _enemyy = Instantiate(_enemy, _points[i].position, _enemy.transform.rotation);
        
        StartCoroutine(Spawn());

    }
}
