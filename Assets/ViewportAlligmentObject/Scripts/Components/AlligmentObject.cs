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
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ViewportAlligmentObject
{

    /// <summary>
    /// Абстрактный компонент с определением базовой логики обтекания об Viewport компонента ScrollRect
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public abstract class AlligmentObject : MonoBehaviour
    {
        protected ScrollRect scrollRect { get; private set; }

        protected RectTransform dummyRectTransform { get; private set; }

        private bool isAlligment = false;

        #region MonoBehaviorRegion
        protected virtual void Awake()
        {
            scrollRect = GetComponentInParent<ScrollRect>();
            if (!scrollRect)
                throw new Exception($"{this} + was spawned not in scrollRect");
            var cachedTransform = transform as RectTransform;
            CreatingDummyObject(new GameObject($"{name} Dummy"));
            var siblingIndex = cachedTransform.GetSiblingIndex();
            dummyRectTransform.SetParent(cachedTransform.parent);
            cachedTransform.SetParent(dummyRectTransform);
            dummyRectTransform.SetSiblingIndex(siblingIndex);
            cachedTransform.sizeDelta = dummyRectTransform.sizeDelta;
        }

        protected virtual void OnEnable()
        {
            scrollRect.onValueChanged.AddListener(CheckAlligment);
            dummyRectTransform.parent.GetComponentOrCreate<TransformChildrenChangedTrigger>().OnChangeTransformChildren += CheckAlligment;
        }

        protected virtual void OnDisable()
        {
            scrollRect.onValueChanged.RemoveListener(CheckAlligment);
            gameObject.GetComponentOrCreate<TransformChildrenChangedTrigger>().OnChangeTransformChildren -= CheckAlligment;
        }
        #endregion MonoBehaviorRegion

        /// <summary>
        /// Создание пустышки с возможностью декорирование наследниками
        /// </summary>
        /// <param name="dummyObject"></param>
        protected virtual void CreatingDummyObject(GameObject dummyObject)
        {
            dummyRectTransform = dummyObject.AddComponent<RectTransform>();
            var cachedTransform = transform as RectTransform;
            dummyRectTransform.GetComponentOrCreate<LayoutElement>
                (
                    (layoutElement) =>
                    {
                        dummyRectTransform.sizeDelta = cachedTransform.sizeDelta;
                        dummyRectTransform.position = cachedTransform.position;
                        layoutElement.preferredHeight = cachedTransform.rect.height;
                        layoutElement.preferredWidth = cachedTransform.rect.width;
                    }
                );
        }

        /// <summary>
        /// Проверка условия обтекания
        /// </summary>
        /// <returns></returns>
        protected abstract bool IsNeedAlligment();

        /// <summary>
        /// Выполнить обтекание
        /// </summary>
        protected abstract void MakeAlligment();

        /// <summary>
        /// Вызвать проверку обтекания
        /// </summary>
        protected void CheckAlligment()
        {
            CheckAlligment(Vector2.zero);
        }

        private void CheckAlligment(Vector2 scrollRectVector)
        {
            var topСondition = IsNeedAlligment();
            if (topСondition && !isAlligment)
            {
                isAlligment = true;
                MakeAlligment();
            }
            else if (!topСondition && isAlligment)
            {
                transform.SetParent(dummyRectTransform);
                isAlligment = false;
                transform.position = dummyRectTransform.position;
            }
        }
    }

}