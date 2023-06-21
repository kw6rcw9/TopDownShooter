using System;

using UnityEngine;

namespace EnemyCore
{
    public abstract class ADetectController : MonoBehaviour
    {
        protected  bool _canSeePlayer;
        public GameObject _player;
        
        
        
        
        public abstract void FieldOfViewCheck(float radius, float angle, LayerMask targetMask, LayerMask obsMask);
        
        
        
        public void SeePlayer(bool see, GameObject player = null)
        {
            _canSeePlayer = see;
            _player = player;
        }

        






    }
}
