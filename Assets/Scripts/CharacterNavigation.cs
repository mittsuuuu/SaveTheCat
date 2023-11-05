using UnityEngine;
using UnityEngine.AI;
using System;


[RequireComponent(typeof(NavMeshAgent))]
public class CharacterNavigation : MonoBehaviour
{
    [SerializeField]
	private Transform m_Target;

    private NavMeshAgent m_Agent;

    public int i;
    public int j;

    private GameObject[,] rooms = new GameObject[4, 4];
    private RoomInfo[,] info = new RoomInfo[4, 4];
    private Transform[,] tf = new Transform[4, 4];

    private int t;
    private int u;
    private int count;
    private int[,] next = new int[4, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
    private int[,] sub;
    private int[] volumes;

    [SerializeField]
    private float thinking;

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();

        rooms[0, 0] = GameObject.Find("1-1");
        rooms[0, 1] = GameObject.Find("1-2");
        rooms[0, 2] = GameObject.Find("1-3");
        rooms[0, 3] = GameObject.Find("1-4");

        rooms[1, 0] = GameObject.Find("2-1");
        rooms[1, 1] = GameObject.Find("2-2");
        rooms[1, 2] = GameObject.Find("2-3");
        rooms[1, 3] = GameObject.Find("2-4");

        rooms[2, 0] = GameObject.Find("3-1");
        rooms[2, 1] = GameObject.Find("3-2");
        rooms[2, 2] = GameObject.Find("3-3");
        rooms[2, 3] = GameObject.Find("3-4");

        rooms[3, 0] = GameObject.Find("4-1");
        rooms[3, 1] = GameObject.Find("4-2");
        rooms[3, 2] = GameObject.Find("4-3");
        rooms[3, 3] = GameObject.Find("4-4");

        info[0, 0] = rooms[0, 0].GetComponent<RoomInfo>();
        info[0, 1] = rooms[0, 1].GetComponent<RoomInfo>();
        info[0, 2] = rooms[0, 2].GetComponent<RoomInfo>();
        info[0, 3] = rooms[0, 3].GetComponent<RoomInfo>();

        info[1, 0] = rooms[1, 0].GetComponent<RoomInfo>();
        info[1, 1] = rooms[1, 1].GetComponent<RoomInfo>();
        info[1, 2] = rooms[1, 2].GetComponent<RoomInfo>();
        info[1, 3] = rooms[1, 3].GetComponent<RoomInfo>();

        info[2, 0] = rooms[2, 0].GetComponent<RoomInfo>();
        info[2, 1] = rooms[2, 1].GetComponent<RoomInfo>();
        info[2, 2] = rooms[2, 2].GetComponent<RoomInfo>();
        info[2, 3] = rooms[2, 3].GetComponent<RoomInfo>();

        info[3, 0] = rooms[3, 0].GetComponent<RoomInfo>();
        info[3, 1] = rooms[3, 1].GetComponent<RoomInfo>();
        info[3, 2] = rooms[3, 2].GetComponent<RoomInfo>();
        info[3, 3] = rooms[3, 3].GetComponent<RoomInfo>();

        tf[0, 0] = rooms[0, 0].GetComponent<Transform>();
        tf[0, 1] = rooms[0, 1].GetComponent<Transform>();
        tf[0, 2] = rooms[0, 2].GetComponent<Transform>();
        tf[0, 3] = rooms[0, 3].GetComponent<Transform>();

        tf[1, 0] = rooms[1, 0].GetComponent<Transform>();
        tf[1, 1] = rooms[1, 1].GetComponent<Transform>();
        tf[1, 2] = rooms[1, 2].GetComponent<Transform>();
        tf[1, 3] = rooms[1, 3].GetComponent<Transform>();

        tf[2, 0] = rooms[2, 0].GetComponent<Transform>();
        tf[2, 1] = rooms[2, 1].GetComponent<Transform>();
        tf[2, 2] = rooms[2, 2].GetComponent<Transform>();
        tf[2, 3] = rooms[2, 3].GetComponent<Transform>();

        tf[3, 0] = rooms[3, 0].GetComponent<Transform>();
        tf[3, 1] = rooms[3, 1].GetComponent<Transform>();
        tf[3, 2] = rooms[3, 2].GetComponent<Transform>();
        tf[3, 3] = rooms[3, 3].GetComponent<Transform>();

        nextTarget();
    }

	void Update()
	{
        if (i == next[t, 0] && j == next[t, 1])
        {
            Invoke("nextTarget", thinking);
            //Debug.Log("change!");
        }
    }

    void nextTarget()
    {
        int[,] pNext = new int[4, 2];
        Array.Copy(next, pNext, next.Length);
        int pT = t;
        t = 0;
        u = 0;
        count = 0;
        next = new int[4, 2];
        sub = new int[4, 2];
        volumes = new int[4];

        if (i > 0 && info[i, j].south == 0)
        {
            if (info[i - 1, j].volume < 30)
            {
                next[t, 0] = i-1;
                next[t, 1] = j;
                t++;
            }
            else
            {
                sub[u, 0] = i - 1;
                sub[u, 1] = j;
                volumes[u] = info[i - 1, j].volume;
                u++;
            }
        }
        if (i < 3 && info[i, j].north == 0)
        {
            if (info[i + 1, j].volume < 30)
            {
                next[t, 0] = i + 1;
                next[t, 1] = j;
                t++;
            }
            else
            {
                sub[u, 0] = i + 1;
                sub[u, 1] = j;
                volumes[u] = info[i + 1, j].volume;
                u++;
            }
        }
        if (j > 0 && info[i, j].west == 0)
        {
            if (info[i, j - 1].volume < 30)
            {
                next[t, 0] = i;
                next[t, 1] = j - 1;
                t++;
            }
            else
            {
                sub[u, 0] = i;
                sub[u, 1] = j - 1;
                volumes[u] = info[i, j - 1].volume;
                u++;
            }
        }
        if (j < 3 && info[i, j].east == 0)
        {
            if (info[i, j + 1].volume < 30)
            {
                next[t, 0] = i;
                next[t, 1] = j + 1;
                t++;
            }
            else
            {
                sub[u, 0] = i;
                sub[u, 1] = j + 1;
                volumes[u] = info[i, j + 1].volume;
                u++;
            }
        }
        
        if (t > 0)
        {
            changeTarget();
        }
        else
        {
            int num = 0;
            int min = 1000;
            bool noChange = false;

            for (int a = 0; a < u; a++)
            {
                if (volumes[a] == 30)
                {
                    volumes[a] += UnityEngine.Random.Range(0, 10) - 2;
                }
                if (volumes[a] < min)
                {
                    min = volumes[a];
                    num = a;
                }
            }
            for (int a = 0; a < u; a++)
            {
                if (volumes[a] == min)
                {
                    count++;
                    Debug.Log(count);
                    if (count == u)
                    {

                        Array.Copy(pNext, next, pNext.Length);
                        t = pT;
                        stay();
                        Debug.Log("Stay");
                        noChange = true;
                    }
                }
            }

            if (!noChange)
            {
                Array.Copy(sub, next, sub.Length);
                t = num;
                subTarget();
            }
        }
        
        void changeTarget()
        {
            t = UnityEngine.Random.Range(0, t);
            m_Target = tf[next[t, 0], next[t, 1]];
            m_Agent.SetDestination(m_Target.position);
        }

        void stay()
        {
            m_Agent.SetDestination(m_Target.position);
        }

        void subTarget()
        {
            m_Target = tf[next[t, 0], next[t, 1]];
            m_Agent.SetDestination(m_Target.position);
        }
    }
}
