            using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject cat;
    [SerializeField] GameObject dirObject;

    Transform ptf; //player Transform
    Transform ctf; //cat Transform
    Transform dtf; //dirObject Transform

    Quaternion offsetRotation;


    Vector3 direction;
    Vector3 playerPos;
    Vector3 catPos;
    Vector3 offsetVector;

    void Start()
    {
        ptf = player.GetComponent<Transform>();
        ctf = cat.GetComponent<Transform>();
        dtf = dirObject.GetComponent<Transform>();
    }

    void Update()
    {
        playerPos = ptf.position;
        catPos = ctf.position;
        direction = catPos - playerPos; // player -> cat‚Ì•ûŒü

        offsetRotation = Quaternion.LookRotation(direction, Vector3.up);
        offsetRotation = new Quaternion(offsetRotation.x, offsetRotation.z, -1.0f * offsetRotation.y, offsetRotation.w);
        
        offsetVector = offsetRotation.eulerAngles;
        offsetVector.z *= -1.0f;

        dtf.rotation = Quaternion.Euler(new Vector3(-90.0f, offsetVector.y, 0));
    }
}
