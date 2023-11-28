using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageLightManager : MonoBehaviour
{
    [SerializeField] // TODO: 後で非シリアライズに。自分で生成するので
    private List<PageLight> pageLights;
    private int activeLightIndex = 0;

    public void Generate()
    {
        // TODO: 生成。
        for(int i = 0; i < pageLights.Count; i++)
        {
            pageLights[i].SetActive(i == 0);
        }
    }

    public void SetPage(int pageIndex)
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
