using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerPageLightManager : MonoBehaviour
{
    [SerializeField]
    private ScrollBanner scrollBanner;
    [SerializeField]
    private PageLight pageLight;

    // Start is called before the first frame update
    void Start()
    {
        pageLight.Generate();
        scrollBanner.OnPageChangeEvent += OnPageChange;
    }

    void OnPageChange(int pageIndex)
    {
        pageLight.SetPage(pageIndex);
    }
}
