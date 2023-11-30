using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollBanner : ScrollRect
{
    // 現在のページ（範囲は0～maxPageIndex）
    private int currentPageIndex = 0;
    // 最大ページ（範囲は0～バナーの数-1）
    private int maxPageIndex = 0;

    // ページ変更の閾値(%)
    [SerializeField, Range(0f, 1f)]
    private float pageChangeThresholdPercent = 0.1f;
    // ページ変更の閾値(Pos) 実際にはこっちを使って閾値判定する。
    private float pageChangeThresholdPos = 0f;

    private bool isDrag = false;
    private float dragBeginPos = 0f;

    // ページ変更した際に発動するイベント
    public delegate void OnPageChange(int pageIndex);
    public event OnPageChange OnPageChangeEvent = delegate { };


    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        isDrag = true;
        dragBeginPos = horizontalNormalizedPosition;
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        isDrag = false;
        var tmp = horizontalNormalizedPosition - dragBeginPos;
        if (tmp > pageChangeThresholdPos)
        {
            NextPage();
            OnPageChangeEvent(currentPageIndex);
        }
        else if (tmp < -pageChangeThresholdPos)
        {
            PrevPage();
            OnPageChangeEvent(currentPageIndex);
        }
    }

    protected override void Start()
    {
        ResetProperties();
    }

    private void Update()
    {
        if (!isDrag)
        {
            if (maxPageIndex != 0)
            {
                var targetPos = (float)currentPageIndex / (float)maxPageIndex;
                horizontalNormalizedPosition = Mathf.Lerp(horizontalNormalizedPosition, targetPos, 0.16f);
            }
        }
    }

    private void NextPage(bool loop = false)
    {
        currentPageIndex++;
        if (maxPageIndex < currentPageIndex)
        {
            currentPageIndex = loop ? 0 : maxPageIndex;
        }
    }
    private void PrevPage(bool loop = false)
    {
        currentPageIndex--;
        if (currentPageIndex < 0)
        {
            currentPageIndex = loop ? maxPageIndex : 0;
        }
    }

    public RectTransform GetContent()
    {
        return content;
    }

    public void ResetProperties()
    {
        maxPageIndex = content.childCount < 0 ? 0 : content.childCount - 1;
        pageChangeThresholdPos = (1f / (float)(maxPageIndex + 1)) * pageChangeThresholdPercent;
    }
#if UNITY_EDITOR
    protected override void OnValidate()
    {
        ResetProperties();
    }
#endif
}
