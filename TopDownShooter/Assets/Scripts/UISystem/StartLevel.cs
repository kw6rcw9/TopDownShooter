using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _speed;
    [SerializeField] private Image _message;
    [SerializeField] private TMP_Text _textGameObject;
    private string _text;

    private void Start()
    {
        _text = _textGameObject.text;
        _textGameObject.text = "";
        StartCoroutine(Fade());
        StartCoroutine(Text());

    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _message.gameObject.SetActive(false);
        }
    }

   

    IEnumerator Fade()
    {
        Color color = _image.color;

        while (color.a > 0f)
        {
            color.a -= _speed * Time.deltaTime;
            _image.color = color;
            yield return null;
            StartCoroutine(Message());
        }
    }

    IEnumerator Message()
    {
        yield return new WaitForSeconds(1f);
        
        _message.transform.DOScale(77,1.5f );
       
        yield return new WaitForSeconds(1f);
        

    }

    IEnumerator Text()
    {
        
        yield return new WaitForSeconds(3f);
       
        foreach (char abc in _text)
        {
            _textGameObject.text += abc;
            yield return new WaitForSeconds(0.05f);

        }
        yield return null;
        gameObject.SetActive(false);
    }
    
}
