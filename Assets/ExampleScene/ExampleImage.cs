using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ExampleImage : MonoBehaviour
{
    private readonly Func<float> randomFunc = () => Random.Range(0f, 1f);

    private void Awake()
    {
        GetComponent<Image>().color = new Color(randomFunc(), randomFunc(), randomFunc());
    }
}
