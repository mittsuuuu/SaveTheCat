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
        //�M������M�����Ƃ��ɁA���̃��b�Z�[�W�̏������s��
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

    //��M�����M��(message)�ɑ΂��鏈��
    void OnDataReceived(string message)
    {
        var data = message.Split(
                new string[] { "\n" }, System.StringSplitOptions.None);
        try
        {
            Debug.Log("ReceieData : " + data[0]);//Unity�̃R���\�[���Ɏ�M�f�[�^��\��
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);//�G���[��\��
        }
    }
}