using DG.Tweening;
using EnemyCore;
using EnemyCore.EnemyHealth;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem.HPSystem
{
    public class EnemyHealthBar : MonoBehaviour
    {


       
            [SerializeField] private Image healthBarImage;
            [SerializeField] private EnemyHealthController enemy;
           
            public void UpdateHealthBar()
            {
                float duration = 0.75f * (enemy.HP / enemy.MaxHP);
                healthBarImage.DOFillAmount( enemy.HP / enemy.MaxHP, duration );
                Color newColor = Color.green;
                if ( enemy.HP < enemy.MaxHP * 0.25f ) {
                    newColor = Color.red;
                } else if ( enemy.HP < enemy.MaxHP * 0.66f ) {
                    newColor = new Color( 1f, .64f, 0f, 1f );
                }
                healthBarImage.DOColor( newColor, duration );
            }
            
        
    }
}
