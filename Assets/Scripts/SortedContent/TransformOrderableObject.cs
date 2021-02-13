using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������� ���������� IOrderableObject
/// </summary>
public class TransformOrderableObject : MonoBehaviour, IOrderableObject
{
    int IOrderableObject.GetSiblingIndex()
    {
        return transform.GetSiblingIndex();
    }

    void IOrderableObject.SetSiblingIndex(int value)
    {
        transform.SetSiblingIndex(value);
    }
}
