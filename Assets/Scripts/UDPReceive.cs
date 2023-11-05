using System;
using UnityEngine;

using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPReceive : MonoBehaviour
{
    MoveScript move;
    Thread thread;

    static UdpClient udp;
    int PC_Port = 9000;

    int[] pointers;
    int threshold; //加速度、ジャイロの閾値

    void Start()
    {
        udp = new UdpClient(PC_Port);
        move = GameObject.FindWithTag("Player").GetComponent<MoveScript>();

        pointers = new int[2];
        threshold = 180;

        thread = new Thread(new ThreadStart(ThreadMethod));
        thread.Start();
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Test Thread OnApplicationQuit");
        thread.Abort();
    }

    private void ThreadMethod()
    {
        Debug.Log("execute Thead");

        while (true)
        {
            IPEndPoint remoteEP = null;

            try
            {
                byte[] data = udp.Receive(ref remoteEP);
                string msg = System.Text.Encoding.UTF8.GetString(data);
                int side = BitConverter.ToInt32(data, 0);
                int acc = BitConverter.ToInt32(data, 4);
                int gyro = BitConverter.ToInt32(data, 8) - 60;

                //Debug.Log("Received data : " + side + ", " + acc + ", " + gyro);

                //if(acc > threshold)
                //{
                //    move.accs[side, pointers[side] % 5] = Math.Abs(acc);
                //    move.Move(side);
                //    move.walk = true;
                //}
                //move.gyros[side, pointers[side] % 5] = gyro;
                //move.Rote();

                //pointers[side] = (pointers[side] + 1) % 5;
            }
            catch(Exception e)
            {
                Debug.Log("Thread has error " + e);
            }
        }
    }
}
