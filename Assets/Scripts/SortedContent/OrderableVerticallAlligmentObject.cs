using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Компонент вертикального обтекания в ScrollRect с возможностью смены позиции внутри LayoutGroup
/// </summary>
public class OrderableVerticallAlligmentObject : VerticalAlligmentObject, IOrderableObject
{
    int IOrderableObject.GetSiblingIndex()
    {
        return dummyRectTransform.GetSiblingIndex();
    }

    void IOrderableObject.SetSiblingIndex(int value)
    {
        dummyRectTransform.SetSiblingIndex(value);
    }
}
