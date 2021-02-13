//MIT License

//Copyright (c) 2021 medzumi

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
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