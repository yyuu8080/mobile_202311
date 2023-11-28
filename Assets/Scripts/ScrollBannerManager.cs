using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBannerManager : MonoBehaviour
{
    [SerializeField]
    private ScrollBanner scrollBanner;
    [SerializeField]
    private PageLightManager pageLightManager;

    // Start is called before the first frame update
    void Start()
    {
        pageLightManager.Generate();
        scrollBanner.OnPageChangeEvent += OnPageChange;
    }

    void OnPageChange(int pageIndex)
    {
        pageLightManager.SetPage(pageIndex);
    }
}
