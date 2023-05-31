using UnityEngine;

namespace UISystem.HPSystem
{
    public class BarHolder : MonoBehaviour
    {
        Quaternion _startRotation = Quaternion.Euler(0,0,0);
    
        void Start() {
        
           transform.rotation = _startRotation;
       
        }
        void Update() {
            transform.rotation = _startRotation;
        
        
        }
    }
}
