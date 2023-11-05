using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] GameObject changescene;
    [SerializeField] TextMeshProUGUI player1;
    [SerializeField] TextMeshProUGUI player2;

    ChangeScene cs;

    public bool start;

    string timeStr;

    [SerializeField]float nowtime;

    void Start()
    {
        cs = changescene.GetComponent<ChangeScene>();

        start = false;

        timeStr = nowtime.ToString("F1");
        player1.text = timeStr;
        player2.text = timeStr;
    }


    void Update()
    {
        if(start)
        {
            if (Input.GetKey(KeyCode .Escape))
            {
                nowtime -= nowtime;
            }
            if (nowtime <= 0)
            {
                cs.changeScene("Player2Win");
            }
            else
            {
                nowtime -= Time.deltaTime;
            }

            timeStr = nowtime.ToString("F1");
            player1.text = timeStr;
            player2.text = timeStr;
        }
    }
}