using System;
using System.Collections;
using UnityEngine;

namespace EnemyCore.EnemyAttack
{
    public class RangeAttack : MonoBehaviour
    {
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.GetComponent<PlayerDetector>())
            {
                StartCoroutine(Return(col));


            }
            else if (col.gameObject.GetComponent<PlayerMovement>())
            {
                col.gameObject.GetComponent<Renderer>().material.color = Color.red;
                
            }
        }

        IEnumerator Return(Collider2D col)
        {
            
            col.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("red");
            yield return new WaitForSeconds(0.3f);
            Debug.Log("white");
            col.gameObject.GetComponent<Renderer>().material.color = Color.white;

        }
        

        
    }
}
