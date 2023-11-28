using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageLightManager : MonoBehaviour
{
    [SerializeField] // TODO: ��Ŕ�V���A���C�Y�ɁB�����Ő�������̂�
    private List<PageLight> pageLights;
    private int activeLightIndex = 0;

    public void Generate()
    {
        // TODO: �����B
        for(int i = 0; i < pageLights.Count; i++)
        {
            pageLights[i].SetActive(i == 0);
        }
    }

    public void SetPage(int pageIndex)
    {
        if(pageIndex < 0 || pageLights.Count < pageIndex)
        {
            Debug.LogError("pageIndex���͈͊O�BpageIndex:" + pageIndex + " pageLights.Count:" + pageLights.Count);
            return;
        }
        pageLights[activeLightIndex].SetActive(false);
        activeLightIndex = pageIndex;
        pageLights[activeLightIndex].SetActive(true);
    }
}
