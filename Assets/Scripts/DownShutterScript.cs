using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownShutterScript : MonoBehaviour
{
    [SerializeField] GameObject[] shutters;
    [SerializeField] Material red;                                                                                                                                      

    Vector3[] originPos;
    Vector3[] endPos;
    bool[] shutterdown;
    bool[] shutterup;

    string tmp;


    public char[] datas;
    int num;

    float[] counttime;

    void Start()
    {
        originPos = new Vector3[3];
        endPos = new Vector3[3];

        originPos[0] = new Vector3(-6.2f, 3.2f, -3.1f);
        originPos[1] = new Vector3(0, 3.2f, -3.1f);
        originPos[2] = new Vector3(6.2f, 3.2f, -3.1f);

        endPos[0] = new Vector3(-6.2f, 1.1f, 3.1f);
        endPos[1] = new Vector3(0, 1.1f, 3.1f);
        endPos[2] = new Vector3(6.2f, 1.1f, 3.1f);

        shutterdown = new bool[shutters.Length];
        shutterup = new bool[shutters.Length];
        counttime = new float[shutters.Length];

        for (int i = 0; i < shutterdown.Length; i++)
        {
            shutterdown[i] = false;
            shutterup[i] = false;
            counttime[i] = 1f;
        }

    }

    void FixedUpdate()
    {
        for (int i = 0; i < shutterdown.Length; i++)
        {
            if (shutterdown[i])
            {
                if (shutters[i].transform.position.y > 1.1f)
                {
                    shutters[i].transform.position += new Vector3(0, -0.005f, 0);
                }
                else
                {
                    shutterdown[i] = false;
                    shutterup[i] = true;
                }
            }
            if (shutterup[i])
            {
                if (shutters[i].transform.position.y < 3.2f)
                {
                    shutters[i].transform.position += new Vector3(0, 0.005f, 0);
                }
                else
                {
                    shutterdown[i] = true;
                    shutterup[i] = false;
                }
            }
        }
    }

    void Update()
    {
        try
        {
            for (int i = 0; i < datas.Length; i++)
            {
                tmp = datas[i].ToString(); //1度string型に変換してあげないとcharをintに変換できない
                num = int.Parse(tmp); //直接ToString()は使えない
                num--;

                shutterdown[num] = true;

                shutters[num].GetComponent<MeshRenderer>().material = red;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e);
        }
    }
    public void GetData()
    {
        
    }
}
