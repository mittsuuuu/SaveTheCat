using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;

public class MultiDisplayScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] �͎�v�ȃf�t�H���g�̃f�B�X�v���C�ŁA��ɃI���ł��B�ł�����A�C���f�b�N�X 1 ����n�܂�܂��B
        // ���̑��̃f�B�X�v���C���g�p�\�����m�F���A���ꂼ����A�N�e�B�u�ɂ��܂��B

        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }
    }
}