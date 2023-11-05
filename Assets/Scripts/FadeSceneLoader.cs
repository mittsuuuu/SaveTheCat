using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeSceneLoader : MonoBehaviour
{
    [SerializeField] Image Canvas1;
    [SerializeField] Image Canvas2;

    float fadeDuration;

    void Start()
    {
        fadeDuration = 1.0f;
    }

    public void FadeOut(string scenename)
    {
        StartCoroutine(FadeOutAndLoadScene(scenename));
    }

    public IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        Canvas1.enabled = true;                 // パネルを有効化
        Canvas2.enabled = true;
        float elapsedTime = 0.0f;                 // 経過時間を初期化
        Color startColor = Canvas1.color;       // フェードパネルの開始色を取得
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // フェードパネルの最終色を設定

        // フェードアウトアニメーションを実行
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;                        // 経過時間を増やす
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);  // フェードの進行度を計算
            Canvas1.color = Color.Lerp(startColor, endColor, t); // パネルの色を変更してフェードアウト
            Canvas2.color = Color.Lerp(startColor, endColor, t);
            yield return null;                                     // 1フレーム待機
        }

        Canvas1.color = endColor;  // フェードが完了したら最終色に設定
        Canvas2.color = endColor;
        SceneManager.LoadScene(sceneName); // シーンをロードしてメニューシーンに遷移
    }
}
