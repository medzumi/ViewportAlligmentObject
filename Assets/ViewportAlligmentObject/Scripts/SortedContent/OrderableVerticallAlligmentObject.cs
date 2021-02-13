

namespace ViewportAlligmentObject
{
    /// <summary>
    /// ��������� ������������� ��������� � ScrollRect � ������������ ����� ������� ������ LayoutGroup
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

}