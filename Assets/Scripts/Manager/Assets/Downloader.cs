using UnityEngine;
using System.Collections;
using Application.Manager.Assets;

namespace Application
{
    public class Downloader : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public delegate IEnumerator CoroutineMethod();

        private IEnumerator RunCoroutine(CoroutineMethod coroutineMethod)
        {
            return coroutineMethod();
        }

        public void StartCoroutineDelegate(CoroutineMethod coroutineMethod)
        {
            StartCoroutine("RunCoroutine", coroutineMethod);
        }
    }
}
