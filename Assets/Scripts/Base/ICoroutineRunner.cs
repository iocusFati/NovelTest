using System.Collections;

namespace UI
{
    public interface ICoroutineRunner
    {
        void StartCoroutine(IEnumerator coroutine);
    }
}