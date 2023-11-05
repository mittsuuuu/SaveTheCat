using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartBlank : MonoBehaviour
{
    MoveScript ms;
    GameControlerScript gcs;
    TimerScript ts;
    LocomotionSimpleAgent lsa;
    CharacterNavigation cn;

    [SerializeField] GameObject PlayerSystem;
    [SerializeField] GameObject NavmeshObj;
    [SerializeField] GameObject SerialReceive;

    [SerializeField] TextMeshProUGUI player1;
    [SerializeField] TextMeshProUGUI player2;

    float nowtime;

    void Start()
    {
        ms = PlayerSystem.GetComponent<MoveScript>();
        gcs = PlayerSystem.GetComponent<GameControlerScript>();
        ts = PlayerSystem.GetComponent<TimerScript>();
        lsa = NavmeshObj.GetComponent<LocomotionSimpleAgent>();
        cn = NavmeshObj.GetComponent<CharacterNavigation>();

        SerialReceive.SetActive(false);

        ms.enabled = false;
        gcs.enabled = false;
        lsa.enabled = false;
        cn.enabled = false;

        nowtime = 0.0f;
    }

    void Update()
    {
        nowtime += Time.deltaTime;

        if (nowtime <= 2.5f)
        {
            player1.text = "Ready";
            player2.text = "Ready";
        }
        else if (nowtime <= 3.25f)
        {
            player1.text = "Go!";
            player2.text = "Go!";
        }
        else
        {
           SerialReceive.SetActive(true);

            //ms.enabled = true;
            gcs.enabled = true;
            lsa.enabled = true;
            cn.enabled = true;

            ts.start = true;

            player1.enabled = false;
            player2.enabled = false;

            this.enabled = false;
        }
    }
}
