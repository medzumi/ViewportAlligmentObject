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

namespace ViewportAlligmentObject
{

    /// <summary>
    /// Экстеншены для триггеров
    /// </summary>
    public static class UnityObjectExtensions
    {
        /// <summary>
        /// Получить компонент у <paramref name="gameObject"/> или создать его, если нет
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static T GetComponentOrCreate<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponentOrCreate<T, T>();
        }

        /// <summary>
        /// Получить компонент у <paramref name="gameObject"/> или создать его, если нет. При создании вызывается <paramref name="onCreateAction"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gameObject"></param>
        /// <param name="onCreateAction"></param>
        /// <returns></returns>
        public static T GetComponentOrCreate<T>(this GameObject gameObject, Action<T> onCreateAction) where T : Component
        {
            if (!gameObject.TryGetComponent<T>(out var result))
            {
                result = gameObject.AddComponent<T>();
                onCreateAction(result);
            }
            return result;
        }

        /// <summary>
        /// Получить компонент у <paramref name="component"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component"></param>
        /// <returns></returns>
        public static T GetComponentOrCreate<T>(this Component component) where T : Component
        {
            return component.gameObject.GetComponentOrCreate<T>();
        }

        /// <summary>
        /// Получить компонент у <paramref name="component"/> или создать его. При создании вызывается <paramref name="onCreateAction"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component"></param>
        /// <param name="onCreateAction"></param>
        /// <returns></returns>
        public static T GetComponentOrCreate<T>(this Component component, Action<T> onCreateAction) where T : Component
        {
            return component.gameObject.GetComponentOrCreate<T>(onCreateAction);
        }

        /// <summary>
        /// Получить компонент у <paramref name="component"/> или создать компонент типа <typeparamref name="TElse"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TElse"></typeparam>
        /// <param name="component"></param>
        /// <returns></returns>
        public static T GetComponentOrCreate<T, TElse>(this Component component) where TElse : Component, T
        {
            return component.gameObject.GetComponentOrCreate<T, TElse>();
        }

        /// <summary>
        /// Получить компонент у <paramref name="gameObject"/> или создать компонент типа <typeparamref name="TElse"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TElse"></typeparam>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static T GetComponentOrCreate<T, TElse>(this GameObject gameObject) where TElse : Component, T
        {
            if(!gameObject.TryGetComponent<T>(out var result))
            {
                result = gameObject.AddComponent<TElse>();
            }
            return result;
        }

        /// <summary>
        /// Получить компонент у <paramref name="component"/> или создать компонент типа <typeparamref name="TElse"/>. При создании вызывается <paramref name="onCreateAction"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TElse"></typeparam>
        /// <param name="component"></param>
        /// <param name="onCreateAction"></param>
        /// <returns></returns>
        public static T GetComponentOrCreate<T, TElse>(this Component component, Action<T> onCreateAction) where TElse : Component, T
        {
            return component.gameObject.GetComponentOrCreate<T, TElse>(onCreateAction);
        }

        /// <summary>
        /// Получить компонент у <paramref name="gameObject"/> или создать компонент типа <typeparamref name="TElse"/>. При создании вызывается <paramref name="onCreateAction"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TElse"></typeparam>
        /// <param name="gameObject"></param>
        /// <param name="onCreateAction"></param>
        /// <returns></returns>
        public static T GetComponentOrCreate<T, TElse>(this GameObject gameObject, Action<T> onCreateAction) where TElse : Component, T
        {
            if (!gameObject.TryGetComponent<T>(out var result))
            {
                result = gameObject.AddComponent<TElse>();
                onCreateAction(result);
            }
            return result;
        }

#if !UNITY_2019_1_OR_NEWER
        public static bool TryGetComponent<T>(this GameObject gameObject, out T result) where T : Component
        {
            result = gameObject.GetComponent<T>();
            return result;
        }

        public static bool TryGetComponent<T>(this Component component, out T result) where T : Component
        {
            return component.gameObject.TryGetComponent(out result);
        }
#endif
    }
}