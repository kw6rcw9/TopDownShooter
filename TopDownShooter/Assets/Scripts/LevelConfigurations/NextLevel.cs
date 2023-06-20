using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Image _image;
    [SerializeField] private GameObject[] _enemies;
    private int i;
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<PlayerMovement>())
        {
            if (Input.GetKey(KeyCode.E) && i == _enemies.Length )
            {
                _image.gameObject.SetActive(true);
                StartCoroutine(Fade());
            }
            
        }
        
    }

    private void Update()
    {
        
        if (i != _enemies.Length)
        {
            if (!_enemies[i].activeSelf)
            { 
                i++;

            }
        } 
        
        
    }

    private void Start()
    {
        i = 0;
    }
    
    IEnumerator Fade()
    {
        Color color = _image.color;

        while (color.a < 1f)
        {
            color.a += _speed * Time.deltaTime;
            _image.color = color;
            yield return null;
           
        }

        
        LevelController.Instance.IsEndGame();
        
    }
}
