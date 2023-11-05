using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    FadeSceneLoader fadeout;
    MoveScript ms;
    GameControlerScript gcs;
    LocomotionSimpleAgent lsa;
    CharacterNavigation cn;

    [SerializeField] GameObject LoadsceneObj;
    [SerializeField] GameObject PlayerSystem;
    [SerializeField] GameObject NavmeshObj;
    [SerializeField] GameObject SerialReceive;

    void Start()
    {
        fadeout = GetComponent<FadeSceneLoader>();
        ms = PlayerSystem.GetComponent<MoveScript>();
        gcs = PlayerSystem.GetComponent<GameControlerScript>();
        lsa = NavmeshObj.GetComponent<LocomotionSimpleAgent>();
        cn = NavmeshObj.GetComponent<CharacterNavigation>();
    }

    public void changeScene(string  sceneName)
    {
        SerialReceive.SetActive(false);

        ms.enabled = false;
        gcs.enabled = false;
        lsa.enabled = false;
        cn.enabled = false;

        fadeout.FadeOut(sceneName);
    }
}
