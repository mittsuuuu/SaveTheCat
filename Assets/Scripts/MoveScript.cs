using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField] GameObject player;

    Rigidbody rb;

    Vector3 moving;

    public bool walk = false;

    float speed = 3.0f;
    float velox;
    float veloz;

    void Start()
    {
        rb = player.GetComponent<Rigidbody>();

        moving = Vector3.zero;

        velox = 0.0f;
        veloz = 0.0f;
    }

    void Update()
    {
        velox = Input.GetAxisRaw("Horizontal");
        veloz = Input.GetAxisRaw("Vertical");

        moving.Set(velox, 0, veloz);
        moving.Normalize();
        moving *= speed;
    }

    private void FixedUpdate()
    {
        rb.velocity = moving;
    }
}
