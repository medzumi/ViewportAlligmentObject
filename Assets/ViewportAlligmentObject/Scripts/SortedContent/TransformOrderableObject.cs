using UnityEngine;

namespace ViewportAlligmentObject
{

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

}