using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

/// <summary>
/// �{�^������������A�w�肵��URL���J��
/// </summary>
public class OpenURL : MonoBehaviour
{
    [SerializeField]
    string url = "https://www.google.co.jp/";
    [SerializeField]
    Button button;

    void Start()
    {
        if (button == null)
        {
            Debug.LogWarning("Button���ݒ肳��Ă��Ȃ��B�I�u�W�F�N�g���F" + this.gameObject.name);
            if (!(button = this.gameObject.GetComponentInChildren<Button>())) return;
        }
        button.onClick.AddListener(() =>
        {
            Application.OpenURL(url);
        });
    }

    private void OnDestroy()
    {
        if (button == null) return;
        button.onClick.RemoveAllListeners();
    }
}
