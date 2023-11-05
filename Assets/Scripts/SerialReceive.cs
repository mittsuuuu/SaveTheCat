using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SerialReceive : MonoBehaviour
{
    public SerialHandler serialHandler;

    float time = 0;
    float limit = 0.5f;

    void Start()
    {
        //信号を受信したときに、そのメッセージの処理を行う
        serialHandler.OnDataReceived += OnDataReceived;
    }

    //private void FixedUpdate()
    //{
    //    time += Time.deltaTime;

    //    if(time >= limit)
    //    {
    //        serialHandler.Write("Serial communication from Unity.");
    //        Debug.Log("Send Serial for Raspberry pi");
    //    }
    //}

    //受信した信号(message)に対する処理
    void OnDataReceived(string message)
    {
        var data = message.Split(
                new string[] { "\n" }, System.StringSplitOptions.None);
        try
        {
            Debug.Log("ReceieData : " + data[0]);//Unityのコンソールに受信データを表示
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);//エラーを表示
        }
    }
}