using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageLightManager : MonoBehaviour
{
    [SerializeField]
    private GameObject lightPrefab;

    // ライトの左右の距離(中心からの距離なので、短くすると重なることもある)
    [SerializeField]
    private float sideDistance = 60f;
    private List<PageLight> pageLights;
    private int activeLightIndex = 0;

    // このスクリプトがついてるオブジェクトの下に、中央ぞろえで生成
    public void Generate(int pageNum)
    {
        // ライトの生成位置。初期位置を求める。（ライトの間隔の数に、ライトの距離をかけて求めている）
        var distanceNum = (pageNum - 1) / 2;
        var halfDistanceNum = (pageNum - 1) % 2;
        float posX = -((distanceNum * sideDistance) + (halfDistanceNum * (sideDistance / 2f)));

        pageLights = new List<PageLight>(pageNum);
        for (int i = 0; i < pageNum; i++)
        {
            var light = Instantiate(lightPrefab, transform);

            var lightPos = light.transform.localPosition;
            lightPos.x += posX; // 生成した位置から相対的に動かす
            light.transform.localPosition = lightPos;
            posX += sideDistance;

            pageLights.Add(light.GetComponent<PageLight>());
            pageLights[i].SetActive(i == activeLightIndex);
        }
    }

    public void ChangePage(int pageIndex)
    {
        if(pageIndex < 0 || pageLights.Count < pageIndex)
        {
            Debug.LogError("pageIndexが範囲外。pageIndex:" + pageIndex + " pageLights.Count:" + pageLights.Count);
            return;
        }
        pageLights[activeLightIndex].SetActive(false);
        activeLightIndex = pageIndex;
        pageLights[activeLightIndex].SetActive(true);
    }
}
