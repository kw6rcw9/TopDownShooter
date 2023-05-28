using DG.Tweening;
using PlayerCore.PlayerHealth;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem.HPSystem
{
    public class PlayerHealthBar : MonoBehaviour
    {


       
            [SerializeField] private Image healthBarImage;
            [SerializeField] private PlayerHealthController player;
            Quaternion startRotation;
            void Start() {
                startRotation = transform.rotation;
            }
            void Update() {
                transform.rotation = startRotation;
            }
            public void UpdateHealthBar()
            {
                float duration = 0.75f * (player.HP / player.MaxHP);
                healthBarImage.DOFillAmount( player.HP / player.MaxHP, duration );
                Color newColor = Color.green;
                if ( player.HP < player.MaxHP * 0.25f ) {
                    newColor = Color.red;
                } else if ( player.HP < player.MaxHP * 0.66f ) {
                    newColor = new Color( 1f, .64f, 0f, 1f );
                }
                healthBarImage.DOColor( newColor, duration );
            }
            
        
    }
}
