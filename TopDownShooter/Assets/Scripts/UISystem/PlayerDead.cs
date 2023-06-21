using System;
using System.Collections;
using System.Collections.Generic;
using PlayerCore.PlayerHealth;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerDead : MonoBehaviour
{
   [FormerlySerializedAs("player")] [SerializeField] private PlayerHealthController _player;
   [FormerlySerializedAs("panel")] [SerializeField] private GameObject _panel;

   private void Start()
   {
       Time.timeScale = 1;
   }

   void Update()
    {
        if (_player.HP == 0)
        {
            Time.timeScale = 0;
            _panel.SetActive(true);
            
        }
       
        
    }

    public  void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
