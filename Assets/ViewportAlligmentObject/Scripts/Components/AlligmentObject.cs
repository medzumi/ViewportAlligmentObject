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