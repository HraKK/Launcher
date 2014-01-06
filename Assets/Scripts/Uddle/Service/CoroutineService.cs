using Uddle.Service.Interface;
using System.Collections;

namespace Uddle.Service
{
    public class CoroutineService : ICoroutineService
    {
        public event CoroutineProxy OnCouroutine;

        public void StartCoroutine(CoroutineMethod coroutine)
        {
            if (OnCouroutine == null)
            {
                return;
            }

            OnCouroutine(coroutine);
        }
    }
}
