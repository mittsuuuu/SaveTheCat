using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArduinoRecieve : MonoBehaviour
{
    public SerialHandler serialHandler;
    TestInputButton testInput;
    ManagementReceiveData mrd;

    [SerializeField] GameObject manegementObj;
    [SerializeField] GameObject shutterController;

    int size;
    int[,] comparison;

    void Start()
    {
        testInput = shutterController.GetComponent<TestInputButton>();
        mrd = manegementObj.GetComponent<ManagementReceiveData>();
        serialHandler.OnDataReceived += OnDataReceived;

        size = 11;
        comparison = new int[size, size];
        for(int i = 0; i < size; i++)
        {
            for(int j = 0; j < size; j++)
            {
                comparison[i, j] = 0;
            }
        }
    }

    void OnDataReceived(string message)
    {
        var data = message.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        var msgs = data[0].Split(new string[] { ":" }, System.StringSplitOptions.None);
        for (int i = 0; i < msgs.Length; i++)
        {
            var msg = msgs[i].Split(new string[] { "," }, System.StringSplitOptions.None);
            //Debug.Log(msg.Length + " : " + msg[0] + ", " + msg[1] + ", " + msg[2] + ", " + msg[3]);
            try
            {
                int ci = int.Parse(msg[0]);
                int cj = int.Parse(msg[1]);
                int key = int.Parse(msg[2]) - 1;

                if(int.Parse(msg[3]) > 0)
                {
                    if (comparison[ci, cj] == 0)
                    {
                        int value = mrd.recieveDatas[key];

                        mrd.recieveDatas[key]++;
                        comparison[ci, cj] = 1;
                    }
                }
                else if(comparison[ci, cj] == 1)
                {
                    mrd.recieveDatas[key]--;
                    comparison[ci, cj] = 0;
                }

            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e.Message);//エラーを表示
            }
        }
    }
}
