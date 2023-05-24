using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace UISystem
{
    public class GameSettings : MonoBehaviour
    {
        [SerializeField] GameObject settingsPanel;
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider sliderEffects;
        [SerializeField] private Slider sliderMusics;
        private bool _isPressed;
        // void Awake()
        // {
        //     if (PlayerPrefs.HasKey("Music")
        //         && PlayerPrefs.HasKey("Effects"))
        //     {
        //         sliderEffects.value = PlayerPrefs.GetFloat("Effects");
        //         sliderMusics.value = PlayerPrefs.GetFloat("Music");
        //     }
        //     else
        //     {
        //         PlayerPrefs.SetFloat("Music", sliderMusics.value);
        //         PlayerPrefs.SetFloat("Effects", sliderEffects.value);
        //     }
        //     
        // }
        private void Start()
        {
            _isPressed = false;
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && _isPressed == false)
            {
                Settings();
                _isPressed = true;

            }
            else if (Input.GetKeyDown(KeyCode.Escape) && _isPressed == true)
            {
                Back();
                _isPressed = false; 
            }
        }

        public void ChangeSound()
        {
            audioMixer.SetFloat("Music", sliderMusics.value);
            audioMixer.SetFloat("Effects", sliderEffects.value);
        }
   
        public void SoundOff()
        {
            audioMixer.SetFloat("Effects", -80f);
            PlayerPrefs.SetFloat("EffectsOff", sliderEffects.value);
        }

        public void MusicOff()
        {
            audioMixer.SetFloat("Music", -80f);
            PlayerPrefs.SetFloat("MusicOff", sliderMusics.value);
        }
       

        public void SoundOn()
        {
            sliderEffects.value = PlayerPrefs.GetFloat("EffectsOff");
        }

        public void MusicOn()
        {
            {
                sliderMusics.value = PlayerPrefs.GetFloat("MusicOff");
            }
        }

        public void Settings()
        {
           
             
            settingsPanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void Back()
        {
            // PlayerPrefs.SetFloat("Music", sliderMusics.value);
            // PlayerPrefs.SetFloat("Effects", sliderEffects.value);
                Time.timeScale = 1;
                settingsPanel.SetActive(false);
            
        }

        public void Menu()
        {
            
                SceneManager.LoadScene(1);
        }
    }
}
