using UnityEngine;
using UnityEngine.SceneManagement;

namespace UISystem
{
    public class GameSettings : MonoBehaviour
    {
        [SerializeField] GameObject settingsPanel;

        public void Settings()
        {
            Debug.Log(" sdsds");
            settingsPanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void Back()
        {
            settingsPanel.SetActive(false);
            Time.timeScale = 1;
        }

        public void Menu()
        {
            SceneManager.LoadScene(1);
        }
    }
}
