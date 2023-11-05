using StateManager;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TouchScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    TouchManager _touch_manager;

    //public GameObject cube;
    Vector3 Pos;

    float time;

    // 初期化
    void Start()
    {
        // タッチ管理マネージャ生成
        this._touch_manager = new TouchManager();
        time = 0;
        text.text = "Start";
    }

    // 更新
    void Update()
    {
        time += Time.deltaTime;
        // タッチ状態更新
        this._touch_manager.update();

        // タッチ取得
        TouchManager touch_state = this._touch_manager.getTouch();

        // タッチされていたら処理
        if (touch_state._touch_flag)
        {
            if (touch_state._touch_phase == TouchPhase.Began)
            {
                // タッチした瞬間の処理
                text.text = time.ToString("F4");
            }
        }
    }
}
