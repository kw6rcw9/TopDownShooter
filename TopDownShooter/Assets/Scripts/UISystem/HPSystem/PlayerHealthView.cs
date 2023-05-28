using PlayerCore.PlayerHealth;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem.HPSystem
{
    public class PlayerHealthView : MonoBehaviour
    {
        [SerializeField] private PlayerHealthController _healthController;
        [SerializeField] private Text _healthText;


        private void OnEnable()
        {
            _healthController.HpChange += HpView;
        }

        private void OnDisable()
        {
            _healthController.HpChange -= HpView;
            
        }

        private void HpView(int hp)
        {
            _healthText.text = "Health: " + hp;
        }
    }
}
