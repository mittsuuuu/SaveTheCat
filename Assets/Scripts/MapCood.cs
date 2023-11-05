using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCood : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject cat;
    [SerializeField] GameObject mapPlayer;
    [SerializeField] GameObject mapCat;

    Transform ptf; //player Transform
    Transform ctf; //cat Transform
    Transform mptf; //mapPlayer Transform
    Transform mctf; //mapCat Transform

    Vector3 playerPos; //player's position
    Vector3 catPos; //cat's position

    void Start()
    {
        ptf = player.GetComponent<Transform>();
        ctf = cat.GetComponent<Transform>();
        mptf = mapPlayer.GetComponent<Transform>();
        mctf = mapCat.GetComponent<Transform>();
    }

    void Update()
    {
        playerPos = ptf.localPosition;
        catPos = ctf.localPosition;
        playerPos.y = 0.5f;
        catPos.y = 0.5f;
        mptf.localPosition = playerPos;
        mctf.localPosition = catPos;
    }
}
