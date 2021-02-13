using UnityEngine;


namespace ViewportAlligmentObject
{
    /// <summary>
    /// ���������� ��� ������ � UI
    /// </summary>
    public static class UIMathfExtentions
    {
        /// <summary>
        /// ����� ��������� ������, ������� �� <paramref name="selfRect"/> �� ������ ������� <paramref name="viewportRect"/>
        /// </summary>
        /// <param name="selfRect"></param>
        /// <param name="viewportRect"></param>
        /// <returns></returns>
        public static bool IsBehindBottom(this RectTransform selfRect, RectTransform viewportRect)
        {
            return viewportRect.position.y + viewportRect.rect.yMin > selfRect.position.y - selfRect.rect.height / 2f;
        }

        /// <summary>
        ///  ����� ��������� ������, ������� �� <paramref name="selfRect"/> �� ������� ������� <paramref name="viewportRect"/>
        /// </summary>
        /// <param name="selfRect"></param>
        /// <param name="viewportRect"></param>
        /// <returns></returns>
        public static bool IsBehindTop(this RectTransform selfRect, RectTransform viewportRect)
        {
            return viewportRect.position.y + viewportRect.rect.yMax < selfRect.position.y + selfRect.rect.height / 2f;
        }
    }
}