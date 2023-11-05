using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputButton : MonoBehaviour
{
    public ShutterController shutter;
    [SerializeField] int mode;

    void Start()
    {
    }

    void Update()
    {
        if (mode == 1)
        {

            if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)0.5);
                }
                else
                {
                    BB1((int)0);
                }
            }
            else
            {
                BB0((int)0);
            }
            if (Input.GetKey(KeyCode.B))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)1.5);
                }
                else
                {
                    BB1((int)1);
                }
            }
            else
            {
                BB0((int)1);
            }
            if (Input.GetKey(KeyCode.C))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)2.5);
                }
                else
                {
                    BB1((int)2);
                }
            }
            else
            {
                BB0((int)2);
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)4.5);
                }
                else
                {
                    BB1((int)4);
                }
            }
            else
            {
                BB0((int)4);
            }
            if (Input.GetKey(KeyCode.E))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)5.5);
                }
                else
                {
                    BB1((int)5);
                }
            }
            else
            {
                BB0((int)5);
            }
            if (Input.GetKey(KeyCode.F))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)6.5);
                }
                else
                {
                    BB1((int)6);
                }
            }
            else
            {
                BB0((int)6);
            }
            if (Input.GetKey(KeyCode.G))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)7.5);
                }
                else
                {
                    BB1((int)7);
                }
            }
            else
            {
                BB0((int)7);
            }
            if (Input.GetKey(KeyCode.H))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)8.5);
                }
                else
                {
                    BB1((int)8);
                }
            }
            else
            {
                BB0((int)8);
            }
            if (Input.GetKey(KeyCode.I))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)9.5);
                }
                else
                {
                    BB1((int)9);
                }
            }
            else
            {
                BB0((int)9);
            }
            if (Input.GetKey(KeyCode.J))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)10.5);
                }
                else
                {
                    BB1((int)10);
                }
            }
            else
            {
                BB0((int)10);
            }
            if (Input.GetKey(KeyCode.K))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)12.5);
                }
                else
                {
                    BB1((int)12);
                }
            }
            else
            {
                BB0((int)12);
            }
            if (Input.GetKey(KeyCode.L))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)13.5);
                }
                else
                {
                    BB1((int)13);
                }
            }
            else
            {
                BB0((int)13);
            }
            if (Input.GetKey(KeyCode.M))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)14.5);
                }
                else
                {
                    BB1((int)14);
                }
            }
            else
            {
                BB0((int)14);
            }
            if (Input.GetKey(KeyCode.N))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)15.5);
                }
                else
                {
                    BB1((int)15);
                }
            }
            else
            {
                BB0((int)15);
            }
            if (Input.GetKey(KeyCode.O))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)16.5);
                }
                else
                {
                    BB1((int)16);
                }
            }
            else
            {
                BB0((int)16);
            }
            if (Input.GetKey(KeyCode.P))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)17.5);
                }
                else
                {
                    BB1((int)17);
                }
            }
            else
            {
                BB0((int)17);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)18.5);
                }
                else
                {
                    BB1((int)18);
                }
            }
            else
            {
                BB0((int)18);
            }
            if (Input.GetKey(KeyCode.R))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)20.5);
                }
                else
                {
                    BB1((int)20);
                }
            }
            else
            {
                BB0((int)20);
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)21.5);
                }
                else
                {
                    BB1((int)21);
                }
            }
            else
            {
                BB0((int)21);
            }
            if (Input.GetKey(KeyCode.T))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)22.5);
                }
                else
                {
                    BB1((int)22);
                }
            }
            else
            {
                BB0((int)22);
            }
            if (Input.GetKey(KeyCode.U))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)23.5);
                }
                else
                {
                    BB1((int)23);
                }
            }
            else
            {
                BB0((int)23);
            }
            if (Input.GetKey(KeyCode.V))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)24.5);
                }
                else
                {
                    BB1((int)24);
                }
            }
            else
            {
                BB0((int)24);
            }
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)25.5);
                }
                else
                {
                    BB1((int)25);
                }
            }
            else
            {
                BB0((int)25);
            }
            if (Input.GetKey(KeyCode.X))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    BB2((int)26.5);
                }
                else
                {
                    BB1((int)26);
                }
            }
            else
            {
                BB0((int)26);
            }
        }
    }

    public void BB0(int a)
    {
        shutter.pushedButton[(int)a / 4, (int)a % 4] = 0;
    }
    public void BB1(int a)
    {
        shutter.pushedButton[(int)a / 4, (int)a % 4] = 1;
    }

    public void BB2(int a) //”L—p‚Ì’Ê˜HŒŠ‚ ‚è
    {
        shutter.pushedButton[(int)a / 4, (int)a % 4] = 2;
    }
}
