using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeMaker : MonoBehaviour
{
    public bool inPlayer = false;
    bool a = true;
    MoveScript walking;
    volumeController vC;
    public Vector2 id = new Vector2(0, 0);
    int i;
    int j;

    private CharacterNavigation cat;

    void Start()
    {
        walking = GameObject.Find("TestPlayer").GetComponent<MoveScript>();
        vC = GameObject.Find("RoomInfo").GetComponent<volumeController>();
        //InvokeRepeating("FootStep", 0.0f, 0.05f);
        i = (int)id.x;
        j = (int)id.y;
        cat = GameObject.FindWithTag("Cat").GetComponent<CharacterNavigation>();
    }
    void Update()
    {
        FootStep();
    }

    void FootStep()
    {
        if (a == true && inPlayer == true)
        {
            vC.MakeVolumeMap(i, j, 50);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inPlayer = true;
        }

        if (other.gameObject.tag == "Cat")
        {
            cat.i = i;
            cat.j = j;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inPlayer = false;
        }
    }
}
