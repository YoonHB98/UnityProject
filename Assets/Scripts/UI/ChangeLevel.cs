using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager _gameManager;
    public GameManager.PlayLevel _playLevel;

    private void Awake()
    {
        _gameManager = GameManager.instance;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
