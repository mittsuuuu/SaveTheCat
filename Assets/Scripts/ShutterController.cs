using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class ShutterController : MonoBehaviour
{
    private GameObject[,] shutter1 = new GameObject[7, 4];
    private GameObject[,] shutter2 = new GameObject[7, 4];
    private Transform[,] tf1 = new Transform[7, 4];
    private Transform[,] tf2 = new Transform[7, 4];
    public int[,] pushedButton = new int[7,4];

    //private float shutterSpeed = 0.005f;
    private float shutterSpeed = 0.02f;

    private RoomInfo[,] rooms = new RoomInfo[4, 4];

    private volumeController vC;


    void Start()
    {
        shutter1[0, 0] = transform.Find("PassableShutters/Shutter1-1").gameObject;
        shutter1[0, 1] = transform.Find("PassableShutters/Shutter1-2").gameObject;
        shutter1[0, 2] = transform.Find("PassableShutters/Shutter1-3").gameObject;

        shutter1[1, 0] = transform.Find("PassableShutters/Shutter2-1").gameObject;
        shutter1[1, 1] = transform.Find("PassableShutters/Shutter2-2").gameObject;
        shutter1[1, 2] = transform.Find("PassableShutters/Shutter2-3").gameObject;
        shutter1[1, 3] = transform.Find("PassableShutters/Shutter2-4").gameObject;

        shutter1[2, 0] = transform.Find("PassableShutters/Shutter3-1").gameObject;
        shutter1[2, 1] = transform.Find("PassableShutters/Shutter3-2").gameObject;
        shutter1[2, 2] = transform.Find("PassableShutters/Shutter3-3").gameObject;

        shutter1[3, 0] = transform.Find("PassableShutters/Shutter4-1").gameObject;
        shutter1[3, 1] = transform.Find("PassableShutters/Shutter4-2").gameObject;
        shutter1[3, 2] = transform.Find("PassableShutters/Shutter4-3").gameObject;
        shutter1[3, 3] = transform.Find("PassableShutters/Shutter4-4").gameObject;

        shutter1[4, 0] = transform.Find("PassableShutters/Shutter5-1").gameObject;
        shutter1[4, 1] = transform.Find("PassableShutters/Shutter5-2").gameObject;
        shutter1[4, 2] = transform.Find("PassableShutters/Shutter5-3").gameObject;

        shutter1[5, 0] = transform.Find("PassableShutters/Shutter6-1").gameObject;
        shutter1[5, 1] = transform.Find("PassableShutters/Shutter6-2").gameObject;
        shutter1[5, 2] = transform.Find("PassableShutters/Shutter6-3").gameObject;
        shutter1[5, 3] = transform.Find("PassableShutters/Shutter6-4").gameObject;

        shutter1[6, 0] = transform.Find("PassableShutters/Shutter7-1").gameObject;
        shutter1[6, 1] = transform.Find("PassableShutters/Shutter7-2").gameObject;
        shutter1[6, 2] = transform.Find("PassableShutters/Shutter7-3").gameObject;


        shutter2[0, 0] = transform.Find("NormalShutters/Shutter1-1").gameObject;
        shutter2[0, 1] = transform.Find("NormalShutters/Shutter1-2").gameObject;
        shutter2[0, 2] = transform.Find("NormalShutters/Shutter1-3").gameObject;

        shutter2[1, 0] = transform.Find("NormalShutters/Shutter2-1").gameObject;
        shutter2[1, 1] = transform.Find("NormalShutters/Shutter2-2").gameObject;
        shutter2[1, 2] = transform.Find("NormalShutters/Shutter2-3").gameObject;
        shutter2[1, 3] = transform.Find("NormalShutters/Shutter2-4").gameObject;

        shutter2[2, 0] = transform.Find("NormalShutters/Shutter3-1").gameObject;
        shutter2[2, 1] = transform.Find("NormalShutters/Shutter3-2").gameObject;
        shutter2[2, 2] = transform.Find("NormalShutters/Shutter3-3").gameObject;

        shutter2[3, 0] = transform.Find("NormalShutters/Shutter4-1").gameObject;
        shutter2[3, 1] = transform.Find("NormalShutters/Shutter4-2").gameObject;
        shutter2[3, 2] = transform.Find("NormalShutters/Shutter4-3").gameObject;
        shutter2[3, 3] = transform.Find("NormalShutters/Shutter4-4").gameObject;

        shutter2[4, 0] = transform.Find("NormalShutters/Shutter5-1").gameObject;
        shutter2[4, 1] = transform.Find("NormalShutters/Shutter5-2").gameObject;
        shutter2[4, 2] = transform.Find("NormalShutters/Shutter5-3").gameObject;

        shutter2[5, 0] = transform.Find("NormalShutters/Shutter6-1").gameObject;
        shutter2[5, 1] = transform.Find("NormalShutters/Shutter6-2").gameObject;
        shutter2[5, 2] = transform.Find("NormalShutters/Shutter6-3").gameObject;
        shutter2[5, 3] = transform.Find("NormalShutters/Shutter6-4").gameObject;

        shutter2[6, 0] = transform.Find("NormalShutters/Shutter7-1").gameObject;
        shutter2[6, 1] = transform.Find("NormalShutters/Shutter7-2").gameObject;
        shutter2[6, 2] = transform.Find("NormalShutters/Shutter7-3").gameObject;

        tf1[0, 0] = transform.Find("PassableShutters/Shutter1-1");
        tf1[0, 1] = transform.Find("PassableShutters/Shutter1-2");
        tf1[0, 2] = transform.Find("PassableShutters/Shutter1-3");

        tf1[1, 0] = transform.Find("PassableShutters/Shutter2-1");
        tf1[1, 1] = transform.Find("PassableShutters/Shutter2-2");
        tf1[1, 2] = transform.Find("PassableShutters/Shutter2-3");
        tf1[1, 3] = transform.Find("PassableShutters/Shutter2-4");

        tf1[2, 0] = transform.Find("PassableShutters/Shutter3-1");
        tf1[2, 1] = transform.Find("PassableShutters/Shutter3-2");
        tf1[2, 2] = transform.Find("PassableShutters/Shutter3-3");

        tf1[3, 0] = transform.Find("PassableShutters/Shutter4-1");
        tf1[3, 1] = transform.Find("PassableShutters/Shutter4-2");
        tf1[3, 2] = transform.Find("PassableShutters/Shutter4-3");
        tf1[3, 3] = transform.Find("PassableShutters/Shutter4-4");

        tf1[4, 0] = transform.Find("PassableShutters/Shutter5-1");
        tf1[4, 1] = transform.Find("PassableShutters/Shutter5-2");
        tf1[4, 2] = transform.Find("PassableShutters/Shutter5-3");

        tf1[5, 0] = transform.Find("PassableShutters/Shutter6-1");
        tf1[5, 1] = transform.Find("PassableShutters/Shutter6-2");
        tf1[5, 2] = transform.Find("PassableShutters/Shutter6-3");
        tf1[5, 3] = transform.Find("PassableShutters/Shutter6-4");

        tf1[6, 0] = transform.Find("PassableShutters/Shutter7-1");
        tf1[6, 1] = transform.Find("PassableShutters/Shutter7-2");
        tf1[6, 2] = transform.Find("PassableShutters/Shutter7-3");


        tf2[0, 0] = transform.Find("NormalShutters/Shutter1-1");
        tf2[0, 1] = transform.Find("NormalShutters/Shutter1-2");
        tf2[0, 2] = transform.Find("NormalShutters/Shutter1-3");

        tf2[1, 0] = transform.Find("NormalShutters/Shutter2-1");
        tf2[1, 1] = transform.Find("NormalShutters/Shutter2-2");
        tf2[1, 2] = transform.Find("NormalShutters/Shutter2-3");
        tf2[1, 3] = transform.Find("NormalShutters/Shutter2-4");

        tf2[2, 0] = transform.Find("NormalShutters/Shutter3-1");
        tf2[2, 1] = transform.Find("NormalShutters/Shutter3-2");
        tf2[2, 2] = transform.Find("NormalShutters/Shutter3-3");

        tf2[3, 0] = transform.Find("NormalShutters/Shutter4-1");
        tf2[3, 1] = transform.Find("NormalShutters/Shutter4-2");
        tf2[3, 2] = transform.Find("NormalShutters/Shutter4-3");
        tf2[3, 3] = transform.Find("NormalShutters/Shutter4-4");

        tf2[4, 0] = transform.Find("NormalShutters/Shutter5-1");
        tf2[4, 1] = transform.Find("NormalShutters/Shutter5-2");
        tf2[4, 2] = transform.Find("NormalShutters/Shutter5-3");

        tf2[5, 0] = transform.Find("NormalShutters/Shutter6-1");
        tf2[5, 1] = transform.Find("NormalShutters/Shutter6-2");
        tf2[5, 2] = transform.Find("NormalShutters/Shutter6-3");
        tf2[5, 3] = transform.Find("NormalShutters/Shutter6-4");

        tf2[6, 0] = transform.Find("NormalShutters/Shutter7-1");
        tf2[6, 1] = transform.Find("NormalShutters/Shutter7-2");
        tf2[6, 2] = transform.Find("NormalShutters/Shutter7-3");

        rooms[0, 0] = GameObject.Find("1-1").GetComponent<RoomInfo>();
        rooms[0, 1] = GameObject.Find("1-2").GetComponent<RoomInfo>();
        rooms[0, 2] = GameObject.Find("1-3").GetComponent<RoomInfo>();
        rooms[0, 3] = GameObject.Find("1-4").GetComponent<RoomInfo>();

        rooms[1, 0] = GameObject.Find("2-1").GetComponent<RoomInfo>();
        rooms[1, 1] = GameObject.Find("2-2").GetComponent<RoomInfo>();
        rooms[1, 2] = GameObject.Find("2-3").GetComponent<RoomInfo>();
        rooms[1, 3] = GameObject.Find("2-4").GetComponent<RoomInfo>();

        rooms[2, 0] = GameObject.Find("3-1").GetComponent<RoomInfo>();
        rooms[2, 1] = GameObject.Find("3-2").GetComponent<RoomInfo>();
        rooms[2, 2] = GameObject.Find("3-3").GetComponent<RoomInfo>();
        rooms[2, 3] = GameObject.Find("3-4").GetComponent<RoomInfo>();

        rooms[3, 0] = GameObject.Find("4-1").GetComponent<RoomInfo>();
        rooms[3, 1] = GameObject.Find("4-2").GetComponent<RoomInfo>();
        rooms[3, 2] = GameObject.Find("4-3").GetComponent<RoomInfo>();
        rooms[3, 3] = GameObject.Find("4-4").GetComponent<RoomInfo>();

        vC = GameObject.Find("RoomInfo").GetComponent<volumeController>();
    }

    void Update()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if(i % 2 == 0 && j == 3)
                {
                    continue;
                }
                if (pushedButton[i, j] == 1)
                {
                    DownShutter1(i, j);
                    UpShutter2(i, j);
                }
                if (pushedButton[i, j] == 2)
                {
                    DownShutter2(i, j);
                    UpShutter1(i, j);
                }
                if(pushedButton[i, j] == 0)
                {
                    UpShutter1(i, j);
                    UpShutter2(i, j);
                }
            }
        }
    }

    void DownShutter1(int i, int j)
    {
        Vector3 pos = tf1[i, j].position;

        if (pos.y > 0.055)
        {
            pos.y -= shutterSpeed;
            //MoveShutter(i, j);
        }

        if (pos.y < 0.060)
        {
            Shuttered(i, j, 1);
        }

        tf1[i, j].position = pos;
    }

    void UpShutter1(int i, int j)
    {
        Vector3 pos = tf1[i, j].position;

        if (pos.y < 2.055)
        {
            pos.y += shutterSpeed;
            //MoveShutter(i, j);

        }

        if (pos.y >= 0.060)
        {
            Shuttered(i, j, 0);
        }

        tf1[i, j].position = pos;
    }

    void DownShutter2(int i, int j)
    {
        Vector3 pos = tf2[i, j].position;

        if (pos.y > 1.15)
        {
            pos.y -= shutterSpeed;
            //MoveShutter(i, j);
        }

        if (pos.y < 1.20)
        {
            Shuttered(i, j, 2);
        }

        tf2[i, j].position = pos;
    }

    void UpShutter2(int i, int j)
    {
        Vector3 pos = tf2[i, j].position;

        if (pos.y < 3.15)
        {
            pos.y += shutterSpeed;
            //MoveShutter(i, j);
        }

        if (pos.y >= 1.20)
        {
            Shuttered(i, j, 0);
        }

        tf2[i, j].position = pos;
    }

    void MoveShutter(int i, int j)
    {
        int k = i / 2;
        if (i % 2 == 0)
        {
            vC.MakeVolumeMap(k, j, 0);
            vC.MakeVolumeMap(k, j + 1, 0);
        }
        else
        {
            vC.MakeVolumeMap(k, j, 0);
            vC.MakeVolumeMap(k + 1, j, 0);
        }
    }

    void Shuttered(int i, int j, int x)
    {
        int k = i / 2;
        if (i % 2 == 0)
        {
            rooms[k, j].east = x;
            rooms[k, j + 1].west = x;
        }
        else
        {
            rooms[k, j].north = x;
            rooms[k + 1, j].south = x;
        }
    }
}
