using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjstVideoPlayer : MonoBehaviour
{
    float width;
    float height;

    void Start()
    {
        RectTransform rectTrasnform = gameObject.GetComponent<RectTransform>();
        width = Screen.width;
        height = Screen.height;

        rectTrasnform.sizeDelta = new Vector2(width, height);
    }
}
