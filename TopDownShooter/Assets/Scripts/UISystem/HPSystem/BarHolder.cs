using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarHolder : MonoBehaviour
{
    Quaternion _startRotation;
    
    void Start() {
        
        _startRotation = transform.rotation;
       
    }
    void Update() {
        transform.rotation = _startRotation;
        
        
    }
}
