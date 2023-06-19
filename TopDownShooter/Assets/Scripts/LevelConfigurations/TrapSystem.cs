using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TrapSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] _traps;
    void Start()
    {

        StartCoroutine(Trap1());
    }

    // Update is called once per frame

    IEnumerator Trap1()
    {
        _traps[0].transform.DOScaleX( 1.15f, 1f);
        _traps[2].transform.DOScaleX( 1.15f, 1f);
        yield return new WaitForSeconds(2);
        _traps[0].transform.DOScaleX( 0f, 1f);
        _traps[2].transform.DOScaleX( 0f, 1f);
        yield return new WaitForSeconds(1);
        _traps[1].transform.DOScaleX( -1f, 1f);
        yield return new WaitForSeconds(2);
        _traps[1].transform.DOScaleX( 0f, 1f);
        yield return new WaitForSeconds(1);
        StartCoroutine(Trap1());
    }
    
}
