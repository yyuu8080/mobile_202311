using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageLight : MonoBehaviour
{
    [SerializeField]
    private Image activeLight;
    [SerializeField]
    private Image inactiveLight;

    public void SetActive(bool isActive)
    {
        activeLight.gameObject.SetActive(isActive);
        inactiveLight.gameObject.SetActive(!isActive);
    }
}
