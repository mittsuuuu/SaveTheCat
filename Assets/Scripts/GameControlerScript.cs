//ゲームコントローラをつないでいるとき用のスクリプト

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlerScript : MonoBehaviour
{
    [SerializeField] GameObject player;

    Rigidbody rb;
    Transform tf;

    Vector3 moving;
    Vector3 rotate;

    public bool walk = false;

    float moveSpeed = 3.0f;
    float rotateSpeed = 1.5f;

    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        tf = player.GetComponent<Transform>();

        moving = Vector3.zero;
        rotate = Vector3.zero;
    }

    void Update()
    {
        InputGamePad();      

        moving.Normalize();
        moving *= moveSpeed;
    }

    void FixedUpdate()
    {
        rb.velocity = moving;

        tf.rotation = Quaternion.Euler(rotate);

        moving = Vector3.zero;
        //rotate = Vector3.zero;
    }

    void InputGamePad()
    {
        //Button A
        if (Input.GetKeyDown("joystick button 0"))
        {
            //Debug.Log("buttonA");
        }
        //Button B
        if (Input.GetKeyDown("joystick button 1"))
        {
            //Debug.Log("buttonB");
        }
        //Button X
        if (Input.GetKeyDown("joystick button 2"))
        {
            //Debug.Log("buttonX");
        }
        //Button Y
        if (Input.GetKeyDown("joystick button 3"))
        {
            //Debug.Log("buttonY");
        }
        //Button LB
        if (Input.GetKeyDown("joystick button 4"))
        {
            //Debug.Log("button LB");
        }
        //Button RB
        if (Input.GetKeyDown("joystick button 5"))
        {
            //Debug.Log("button RB");
        }

        //L Stick
        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");
        if ((lsh != 0) || (lsv != 0))
        {
            //Debug.Log("L stick:" + lsh + ", " + lsv);

            moving = tf.forward * lsv + tf.right * lsh;
        }
        //R Stick
        float rsh = Input.GetAxis("R_Stick_H");
        float rsv = Input.GetAxis("R_Stick_V");
        if ((rsh >= 0.2) || (rsh <= -0.2))
        {
            //Debug.Log("R stick:" + rsh + ", " + rsv);
            rotate.Set(0, rsh * rotateSpeed, 0);
            rotate += tf.rotation.eulerAngles;
        }

        //D-Pad
        float dph = Input.GetAxis("D_Pad_H");
        float dpv = Input.GetAxis("D_Pad_V");
        if ((dph != 0) || (dpv != 0))
        {
            //Debug.Log("D Pad:" + dph + ", " + dpv);
        }

        //Trigger
        float tri = Input.GetAxis("L_R_Trigger");
        if (tri > 0)
        {
            //Debug.Log("R trigger:" + tri);
        }
        else if (tri < 0)
        {
            //Debug.Log("L trigger:" + tri);
        }
    }
}
