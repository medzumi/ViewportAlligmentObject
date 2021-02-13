using UnityEngine;


namespace ViewportAlligmentObject
{
    /// <summary>
    /// Ёкстеншены дл€ работы с UI
    /// </summary>
    public static class UIMathfExtentions
    {
        /// <summary>
        /// ћетод позвол€ет узнать, выходит ли <paramref name="selfRect"/> за нижнию границу <paramref name="viewportRect"/>
        /// </summary>
        /// <param name="selfRect"></param>
        /// <param name="viewportRect"></param>
        /// <returns></returns>
        public static bool IsBehindBottom(this RectTransform selfRect, RectTransform viewportRect)
        {
            return viewportRect.position.y + viewportRect.rect.yMin > selfRect.position.y - selfRect.rect.height / 2f;
        }

        /// <summary>
        ///  ћетод позвол€ет узнать, выходит ли <paramref name="selfRect"/> за верхнюю границу <paramref name="viewportRect"/>
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