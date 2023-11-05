using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject cat;
    [SerializeField] GameObject dirObject;
    [SerializeField] GameObject targetObject;

    Transform ptf; //player Transform
    Transform ctf; //cat Transform
    Transform dtf; //dirObject Transform
    Transform ttf;

    Vector2 zerodire;
    Vector2 direction;

    Vector3 playerPos;
    Vector3 catPos;
    Vector3 axis;

    Quaternion qua;

    float beforangle;
    float direCat;
    float degdire;

    void Start()
    {
        ptf = player.GetComponent<Transform>();
        ctf = cat.GetComponent<Transform>();
        dtf = dirObject.GetComponent<Transform>();
        ttf = targetObject.GetComponent<Transform>();

        direction = new Vector2();
        zerodire = new Vector2(1f, 0);

        playerPos = new Vector3();
        catPos = new Vector3();

        beforangle = 0.0f;

        axis = new Vector3(0, 1.0f, 0);
    }

    void Update()
    {
        axis = ptf.position - ttf.position;
        qua = Quaternion.LookRotation(axis, Vector3.up);

        dtf.rotation = new Quaternion(qua.x, qua.z, -qua.y, qua.w);
    }
}