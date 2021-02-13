using System;
using UnityEngine;

namespace ViewportAlligmentObject
{

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

}