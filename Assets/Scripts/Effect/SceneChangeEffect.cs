using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeEffect : MonoBehaviour
{
    public CanvasGroup _canvasGroup;
    public bool _fadein = false;
    public bool _fadeout = false;

    public float _fadeTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_fadein == true)
        {
            if(_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += _fadeTime * Time.deltaTime;
            }
            else
            {
                _canvasGroup.alpha = 1;
                _fadein = false;
            }
        }else
        if(_fadeout == true)
        {
            if(_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= _fadeTime * Time.deltaTime;
            }
            else
            {
                _canvasGroup.alpha = 0;
                _fadeout = false;
            }
        }
    }

    public void FadeIn()
    {
        _fadein = true;
    }

    public void FadeOut()
    {
        _fadeout = true;
    }

}
