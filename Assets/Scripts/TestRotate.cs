using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotate : MonoBehaviour
{
    [SerializeField] GameObject maproom;

    Transform tf;

    float time;

    void Start()
    {
        tf = maproom.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        time += Time.deltaTime / 2f;
        tf.rotation = Quaternion.Euler(new Vector3(Mathf.Sin(time) * 360, 0, Mathf.Cos(time) * 360));
    }
}
