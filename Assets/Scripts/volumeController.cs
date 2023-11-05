using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeController : MonoBehaviour
{
    [System.NonSerialized]
    public int[,] volumeMap = new int[4, 4];

    private RoomInfo[,] rooms = new RoomInfo[4, 4];

    void Start()
    {
        rooms[0,0] = GameObject.Find("1-1").GetComponent<RoomInfo>();
        rooms[0,1] = GameObject.Find("1-2").GetComponent<RoomInfo>();
        rooms[0,2] = GameObject.Find("1-3").GetComponent<RoomInfo>();
        rooms[0,3] = GameObject.Find("1-4").GetComponent<RoomInfo>();

        rooms[1,0] = GameObject.Find("2-1").GetComponent<RoomInfo>();
        rooms[1,1] = GameObject.Find("2-2").GetComponent<RoomInfo>();
        rooms[1,2] = GameObject.Find("2-3").GetComponent<RoomInfo>();
        rooms[1,3] = GameObject.Find("2-4").GetComponent<RoomInfo>();

        rooms[2,0] = GameObject.Find("3-1").GetComponent<RoomInfo>();
        rooms[2,1] = GameObject.Find("3-2").GetComponent<RoomInfo>();
        rooms[2,2] = GameObject.Find("3-3").GetComponent<RoomInfo>();
        rooms[2,3] = GameObject.Find("3-4").GetComponent<RoomInfo>();

        rooms[3,0] = GameObject.Find("4-1").GetComponent<RoomInfo>();
        rooms[3,1] = GameObject.Find("4-2").GetComponent<RoomInfo>();
        rooms[3,2] = GameObject.Find("4-3").GetComponent<RoomInfo>();
        rooms[3,3] = GameObject.Find("4-4").GetComponent<RoomInfo>();

        
    }

    public void MakeVolumeMap(int i, int j, int x)
    {
        
        volumeMap = new int[,]{ { 0, 0, 0, 0 },
                                { 0, 0, 0, 0 },
                                { 0, 0, 0, 0 },
                                { 0, 0, 0, 0 } };

        Recursion(i, j, x);
    }
 
    void Recursion(int i, int j, int x)
    {
        volumeMap[i, j] = x;
        if (x > 0)
        {
            if (i > 0 && rooms[i,j].south == 0)
            {
                if (x > volumeMap[i - 1, j])
                {
                    Recursion(i - 1, j, x - 10);
                }
            }
            if (i < 3 && rooms[i, j].north == 0)
            {
                if (x > volumeMap[i + 1, j])
                {
                    Recursion(i + 1, j, x - 10);
                }
            }
            if (j > 0 && rooms[i,j].west == 0)
            {
                if (x > volumeMap[i, j - 1])
                {
                    Recursion(i, j - 1, x - 10);
                }
            }
            if (j < 3 && rooms[i,j].east == 0)
            {
                if (x > volumeMap[i, j + 1])
                {
                    Recursion(i, j + 1, x - 10);
                }
            }
        }

        CopyVolumeMap();
    }

    void CopyVolumeMap()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                rooms[i,j].volume = volumeMap[i,j];
            }
        }
    }
}
