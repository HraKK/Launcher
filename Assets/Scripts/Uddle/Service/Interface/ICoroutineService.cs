using System.Collections;

namespace Uddle.Service.Interface
{
    public delegate IEnumerator CoroutineMethod();
    public delegate void CoroutineProxy(CoroutineMethod coroutine);

    interface ICoroutineService : IService
    {
        event CoroutineProxy OnCouroutine;
        void StartCoroutine(CoroutineMethod coroutine);
    }
}