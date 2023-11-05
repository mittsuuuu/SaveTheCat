using Oculus.Platform;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShutterDown : MonoBehaviour
{
    [SerializeField] GameObject shutter;

    public String data;
    String[] buffer;

    Vector3 originPos;
    Vector3 endPos;

    bool isShutterdown;
    bool isShutterup;

    int[] msg = new int[2];

    private void Start()
    {
        originPos = new Vector3(0, 3.2f, -9.3f);
        endPos = new Vector3(0, 1.1f, -9.3f);
        isShutterdown = false;
        isShutterup = false;
    }

    void Update()
    {
        //Debug.Log(data);

        buffer = data.Split(",");
        try
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                msg[i] = int.Parse(buffer[i]);

                Debug.Log(i + ":" + msg[i]);
            }
        }
        catch(System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
        
    }

    private void FixedUpdate()
    {
        if (msg[1] == 1)
        {
            isShutterdown = true;
            ShutterMove();
        }
    }

    void ShutterMove()
    {
        if(isShutterdown)
        {
            if(shutter.transform.position.y > endPos.y)
            {
                shutter.transform.position += new Vector3(0, -0.005f, 0);
            }
            else
            {
                isShutterdown = false;
                isShutterup = true;
            }
        }
        if(isShutterup)
        {
            if (shutter.transform.position.y < 3.2f)
            {
                shutter.transform.position += new Vector3(0, 0.005f, 0);
            }
            else
            {
                isShutterdown = true;
                isShutterup = false;
            }
        }
    }
}

