using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestText : MonoBehaviour
{
    public Player player;
    public TMP_Text Text;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Text.text = "HP : " + player._hp + "\n" + "Coin : " + player._coin;
        }
    }
}
