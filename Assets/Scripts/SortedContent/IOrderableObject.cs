using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Интерфейс смены позиции объекта
/// </summary>
public interface IOrderableObject
{
    /// <summary>
    /// Получить текущую позицию объекта
    /// </summary>
    /// <returns></returns>
    int GetSiblingIndex();

    /// <summary>
    /// Установить позицию объекта
    /// </summary>
    /// <param name="value"></param>
    void SetSiblingIndex(int value);
}