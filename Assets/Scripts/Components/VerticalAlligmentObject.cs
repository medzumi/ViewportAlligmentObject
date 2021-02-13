using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///Реализация обтекания в вертикальном ScrollRect
/// </summary>
[RequireComponent(typeof(RectTransform))]
public class VerticalAlligmentObject : AlligmentObject
{
    protected override bool IsNeedAlligment()
    {
        return dummyRectTransform.IsBehindBottom(scrollRect.viewport) || dummyRectTransform.IsBehindTop(scrollRect.viewport);
    }

    protected override void MakeAlligment()
    {
        transform.SetParent(scrollRect.viewport);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, scrollRect.viewport.position.y + scrollRect.viewport.rect.yMin + dummyRectTransform.rect.height/2f, scrollRect.viewport.position.y + scrollRect.viewport.rect.yMax - dummyRectTransform.rect.height/2f));
    }
}
