using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustScreenSize : MonoBehaviour
{
    float width;
    float height;

    void Start()
    {
        RectTransform rectTrasnform = gameObject.GetComponent<RectTransform>();
        width = Screen.width;
        height = Screen.height;

        rectTrasnform.sizeDelta = new Vector2(width * 1.5f, height * 1.5f);
    }
}
