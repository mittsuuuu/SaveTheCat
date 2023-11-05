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
        Canvas1.enabled = true;                 // �p�l����L����
        Canvas2.enabled = true;
        float elapsedTime = 0.0f;                 // �o�ߎ��Ԃ�������
        Color startColor = Canvas1.color;       // �t�F�[�h�p�l���̊J�n�F���擾
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // �t�F�[�h�p�l���̍ŏI�F��ݒ�

        // �t�F�[�h�A�E�g�A�j���[�V���������s
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;                        // �o�ߎ��Ԃ𑝂₷
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);  // �t�F�[�h�̐i�s�x���v�Z
            Canvas1.color = Color.Lerp(startColor, endColor, t); // �p�l���̐F��ύX���ăt�F�[�h�A�E�g
            Canvas2.color = Color.Lerp(startColor, endColor, t);
            yield return null;                                     // 1�t���[���ҋ@
        }

        Canvas1.color = endColor;  // �t�F�[�h������������ŏI�F�ɐݒ�
        Canvas2.color = endColor;
        SceneManager.LoadScene(sceneName); // �V�[�������[�h���ă��j���[�V�[���ɑJ��
    }
}
