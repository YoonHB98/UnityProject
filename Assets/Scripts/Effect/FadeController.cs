using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    public SceneChangeEffect fade;
    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType<SceneChangeEffect>();

        if(fade == null)
        {
            Debug.LogError("SceneChangeEffect is not found");
        }else
        {
            fade.FadeOut();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
