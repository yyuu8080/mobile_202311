using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ScrollBannerManager : MonoBehaviour
{
    [SerializeField]
    private ScrollBanner scrollBanner;
    [SerializeField]
    private GameObject bannerPrefab;
    [SerializeField]
    private PageLightManager pageLightManager;

    private const string jsonPath = "Assets/Resources/banner.json";
    [Serializable]
    public class JsonData
    {
        public int count;
        public BannerData[] bannerDatas;
    }
    [Serializable]
    public class BannerData
    {
        public string url;
        public string dataPath;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Jsonの読み込み
        var json = LoadJson();

        // bannerの生成
        for(int i = 0; i < json.count; i++)
        {
            var banner = Instantiate(bannerPrefab, scrollBanner.GetContent().transform);
            // Image設定
            var bannerImg = banner.GetComponent<Image>();
            Debug.Assert(bannerImg != null, "BannerプレハブのImageコンポーネントを取得できません");
            bannerImg.sprite = Resources.Load<Sprite>(json.bannerDatas[i].dataPath);
            // URL設定
            var openUrl = banner.GetComponent<OpenURL>();
            Debug.Assert(openUrl != null, "BannerプレハブのOpenURLコンポーネントを取得できません");
            openUrl.url = json.bannerDatas[i].url;
        }
        scrollBanner.ResetProperties();
        scrollBanner.OnPageChangeEvent += OnPageChange;

        pageLightManager.Generate(json.count);
    }

    void OnPageChange(int pageIndex)
    {
        pageLightManager.ChangePage(pageIndex);
    }

    private JsonData LoadJson()
    {
        JsonData json;
        if (!File.Exists(jsonPath))
        {
            Debug.LogError("json not exists:" + jsonPath);
            json = new JsonData();
            return json;
        }

        var jsonTxt = File.ReadAllText(jsonPath);
        json = JsonUtility.FromJson<JsonData>(jsonTxt);
        return json;
    }
}
