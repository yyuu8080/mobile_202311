using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageLightManager : MonoBehaviour
{
    [SerializeField]
    private GameObject lightPrefab;

    // ���C�g�̍��E�̋���(���S����̋����Ȃ̂ŁA�Z������Əd�Ȃ邱�Ƃ�����)
    [SerializeField]
    private float sideDistance = 60f;
    private List<PageLight> pageLights;
    private int activeLightIndex = 0;

    // ���̃X�N���v�g�����Ă�I�u�W�F�N�g�̉��ɁA�������낦�Ő���
    public void Generate(int pageNum)
    {
        // ���C�g�̐����ʒu�B�����ʒu�����߂�B�i���C�g�̊Ԋu�̐��ɁA���C�g�̋����������ċ��߂Ă���j
        var distanceNum = (pageNum - 1) / 2;
        var halfDistanceNum = (pageNum - 1) % 2;
        float posX = -((distanceNum * sideDistance) + (halfDistanceNum * (sideDistance / 2f)));

        pageLights = new List<PageLight>(pageNum);
        for (int i = 0; i < pageNum; i++)
        {
            var light = Instantiate(lightPrefab, transform);

            var lightPos = light.transform.localPosition;
            lightPos.x += posX; // ���������ʒu���瑊�ΓI�ɓ�����
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
            Debug.LogError("pageIndex���͈͊O�BpageIndex:" + pageIndex + " pageLights.Count:" + pageLights.Count);
            return;
        }
        pageLights[activeLightIndex].SetActive(false);
        activeLightIndex = pageIndex;
        pageLights[activeLightIndex].SetActive(true);
    }
}
