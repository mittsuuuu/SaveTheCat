using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementReceiveData : MonoBehaviour
{
    TestInputButton testInput;

    [SerializeField] GameObject shutterController;

    public Dictionary<int, int> recieveDatas = new Dictionary<int, int>()
    {
        {0, 0 },
        {1, 0 },
        {2, 0 },
        {4, 0 },
        {5, 0 },
        {6, 0 },
        {7, 0 },
        {8, 0 },
        {9, 0 },
        {10, 0 },
        {12, 0 },
        {13, 0 },
        {14, 0 },
        {15, 0 },
        {16, 0 },
        {17, 0 },
        {18, 0 },
        {20, 0 },
        {21, 0 },
        {22, 0 },
        {23, 0 },
        {24, 0 },
        {25, 0 },
        {26, 0 }
    };

    void Start()
    {
        testInput = shutterController.GetComponent<TestInputButton>();
    }

    void Update()
    {
        foreach(var dk in recieveDatas)
        {
            int key = dk.Key;
            int value = dk.Value;
            
            if(value == 0)
            {
                testInput.BB0(key);
            }
            else if(value == 1)
            {
                testInput.BB1(key);
                Debug.Log(key + ", " + value + " : " + "BB0");
            }
            else
            {
                testInput.BB2(key);
                Debug.Log(key + ", " + value + " : " + "BB1");
            }
        }
    }
}
