using System;
using UnityEngine;

namespace ViewportAlligmentObject
{

    /// <summary>
    /// Триггер изменения иерархии дочерних объектов
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