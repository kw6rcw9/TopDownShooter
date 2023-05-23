using UnityEngine;
using UnityEngine.SceneManagement;

namespace UISystem
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] GameObject settingsPanel;
        [SerializeField] GameObject menuPanel;
        public void Quit()
        {
            Application.Quit();
        }

        public void Play()
        {
            SceneManager.LoadScene(0);
        }
        public void Settings()
        {
            settingsPanel.SetActive(true);
            menuPanel.SetActive(false);
            
            
        }

        public void Back()
        {
            settingsPanel.SetActive(false);
            menuPanel.SetActive(true);
        }
    
    }
}
