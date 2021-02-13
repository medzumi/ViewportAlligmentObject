using System.Collections;
using UnityEngine;

namespace ViewportAlligmentObject.Example
{
    public class Shaker : MonoBehaviour
    {
        [SerializeField]
        private GameObject exampleObject;

        private void Awake()
        {
            for (int i = 0; i < 50; i++)
            {
                Instantiate(exampleObject, transform);
            }
        }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                transform.GetChild(Random.Range(0, transform.childCount))
                .SetSiblingIndex(Random.Range(0, transform.childCount));
            }
        }
    }

}