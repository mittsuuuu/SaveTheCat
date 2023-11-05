using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMapColor : MonoBehaviour
{
    [SerializeField] Material changecolor;
    [SerializeField] Material origincolor;

    GameObject collision;
    Material[] material;
    Material[] mats;

    void Start()
    {
        mats = new Material[1];
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Stage"))
        {
            collision = other.gameObject;
            material = collision.GetComponent<Renderer>().materials;
            mats[0] = changecolor;
            material = mats;
            collision.GetComponent<Renderer>().materials = material;
            //Debug.Log(collision.name);
        }
        
    }

    void OnCollisionExit(Collision other)
    {
        collision = other.gameObject;
        material = collision.GetComponent<Renderer>().materials;
        mats[0] = origincolor;
        material = mats;
        collision.GetComponent<Renderer>().materials = material;
    }
}
