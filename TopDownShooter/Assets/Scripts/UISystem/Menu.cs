using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UISystem
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private GameObject _instructionPanel;
        [SerializeField] private GameObject _settingsPanel;
        [SerializeField] private GameObject _loadPanel;
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private Slider _sliderEffects;
        [SerializeField] private Slider _sliderMusics;

        
        void Awake()
        {
            if (PlayerPrefs.HasKey("Music")
                && PlayerPrefs.HasKey("Effects"))
            {
                _sliderEffects.value = PlayerPrefs.GetFloat("Effects");
                _sliderMusics.value = PlayerPrefs.GetFloat("Music");
            }
            else
            {
                PlayerPrefs.SetFloat("Music", _sliderMusics.value);
                PlayerPrefs.SetFloat("Effects", _sliderEffects.value);
            }
            Debug.Log(_sliderMusics.value);
        
        }

        public void Play()
        {
            PlayerPrefs.Save();

            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }

        public void Settings()
        {
            _menuPanel.SetActive(false);
            _settingsPanel.SetActive(true);
        }
        public void Instruction()
        {
            _menuPanel.SetActive(false);
            _instructionPanel.SetActive(true);
        }
        public void Load()
        {
            _menuPanel.SetActive(false);
            _loadPanel.SetActive(true);
        }

        public void Back()
        {
            PlayerPrefs.SetFloat("Music", _sliderMusics.value);
            PlayerPrefs.SetFloat("Effects", _sliderEffects.value);

            _menuPanel.SetActive(true);
            
            _settingsPanel.SetActive(false);
            _loadPanel.SetActive(false);
            _instructionPanel.SetActive(false);
            
        }

        public void ChangeSound()
        {
            _audioMixer.SetFloat("Music", _sliderMusics.value);
            _audioMixer.SetFloat("Effects", _sliderEffects.value);

        }

        public void SoundOff()
        {
            _audioMixer.SetFloat("Effects", -80f);
            PlayerPrefs.SetFloat("EffectsOff", _sliderEffects.value);
       
        }

        public void MusicOff()
        {
            _audioMixer.SetFloat("Music", -80f);
            PlayerPrefs.SetFloat("MusicOff", _sliderMusics.value);
         
        }
        
        private void SoundOn()
        {
            _sliderEffects.value = PlayerPrefs.GetFloat("EffectsOff");
         
        }

        private void MusicOn()
        {
            _sliderMusics.value = PlayerPrefs.GetFloat("MusicOff");

        }

        void Quit()
        {
            Application.Quit();
        }
    }
    
}

