using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMonitorCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject cat;

    private CharacterNavigation nav;

    Vector3 pos;

    void Start()
    {
        pos = this.transform.position;
        nav = cat.GetComponent<CharacterNavigation>();
    }


    void Update()
    {
        Vector3 newPos = pos + new Vector3(6.2f * nav.j, 0, 6.2f * nav.i);
        this.transform.position = newPos;
    }
}
