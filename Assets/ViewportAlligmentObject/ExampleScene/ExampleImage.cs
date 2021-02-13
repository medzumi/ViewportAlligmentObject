using System;
using UnityEngine;
using UnityEngine.UI;

namespace ViewportAlligmentObject.Example
{
    using Random = UnityEngine.Random;

    public class ExampleImage : MonoBehaviour
    {
        private readonly Func<float> randomFunc = () => Random.Range(0f, 1f);

        private void Awake()
        {
            GetComponent<Image>().color = new Color(randomFunc(), randomFunc(), randomFunc());
        }
    }

}