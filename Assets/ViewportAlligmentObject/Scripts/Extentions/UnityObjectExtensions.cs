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
            return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
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
            return gameObject.GetComponent<T>() ?? gameObject.AddComponent<TElse>();
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
    }
}