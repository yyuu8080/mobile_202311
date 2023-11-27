using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageLight : MonoBehaviour
{
    [SerializeField] // TODO: 後で非シリアライズに。自分で生成するので
    private List<Image> activeLights;
    [SerializeField] // TODO: 後で非シリアライズに。自分で生成するので
    private List<Image> inactiveLights;
    private int activePageIndex = 0;

    public void Generate()
    {
        // TODO: 生成。
        for(int i = 0; i < activeLights.Count; i++)
        {
            activeLights[i].gameObject.SetActive(i == activePageIndex);
            inactiveLights[i].gameObject.SetActive(i != activePageIndex);
        }
    }

    public void SetPage(int pageIndex)
    {
        if(pageIndex < 0 || activeLights.Count < pageIndex)
        {
            Debug.LogError("pageIndexが範囲外。pageIndex:" + pageIndex + " activeLights.Count:" + activeLights.Count);
            return;
        }
        activeLights[activePageIndex].gameObject.SetActive(false);
        inactiveLights[activePageIndex].gameObject.SetActive(true);
        activePageIndex = pageIndex;
        activeLights[activePageIndex].gameObject.SetActive(true);
        inactiveLights[activePageIndex].gameObject.SetActive(false);
    }
}
