using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Switching : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pushRe;
    float duration = 1.0f;

    Color32 startColor = new Color32(255, 255, 255, 255);
    Color32 endColor = new Color32(255, 255, 255, 10);

    void Start()
    {
        
    }

    void Update()
    {
        pushRe.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));
    }
}
