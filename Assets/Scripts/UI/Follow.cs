using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position);
        rectTransform.position = screenPoint;
    }
}
