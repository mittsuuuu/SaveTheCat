using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchCat : MonoBehaviour
{
    [SerializeField] GameObject changeScene;

    ChangeScene cs;

    void Start()
    {
        cs = changeScene.GetComponent<ChangeScene>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cat"))
        {
            Debug.Log("Player1 win");
            cs.changeScene("Player1Win");
        }
    }
}
