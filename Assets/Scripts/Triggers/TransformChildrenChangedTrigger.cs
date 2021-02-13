using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������� ��������� �������� �������� ��������
/// </summary>
public class TransformChildrenChangedTrigger : MonoBehaviour
{
    public event Action OnChangeTransformChildren = delegate { };

    private void OnTransformChildrenChanged()
    {
        OnChangeTransformChildren();
    }
}
