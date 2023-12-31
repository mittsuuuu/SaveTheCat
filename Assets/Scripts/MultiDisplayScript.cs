using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;

public class MultiDisplayScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] は主要なデフォルトのディスプレイで、常にオンです。ですから、インデックス 1 から始まります。
        // その他のディスプレイが使用可能かを確認し、それぞれをアクティブにします。

        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }
    }
}