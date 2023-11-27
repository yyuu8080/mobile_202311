using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

/// <summary>
/// ボタンを押したら、指定したURLを開く
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
            Debug.LogWarning("Buttonが設定されていない。オブジェクト名：" + this.gameObject.name);
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
