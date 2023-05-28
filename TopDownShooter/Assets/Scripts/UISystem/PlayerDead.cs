using System.Collections;
using System.Collections.Generic;
using PlayerCore.PlayerHealth;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
   [SerializeField] private PlayerHealthController player;
   [SerializeField] private GameObject panel;

    
    void Update()
    {
        if (player.HP == 0)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
            
        }
       
        
    }

    public  void Menu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
