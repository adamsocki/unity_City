/*using UnityEngine;
using System.Collections.Generic;

public class CoroutineManager : MonoBehaviour
{
    // Singleton instance
    private static CoroutineManager _instance;
    public static CoroutineManager Instance { get { return _instance; } }

    // List of active coroutines
    private List<Coroutine> _activeCoroutines = new List<Coroutine>();

    private void Awake()
    {
        // Singleton pattern
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Starts a new coroutine and adds it to the list of active coroutines
    public Coroutine StartCoroutine(IEnumerator routine)
    {
        Coroutine coroutine = base.StartCoroutine(routine);
        _activeCoroutines.Add(coroutine);
        return coroutine;
    }

    // Stops a coroutine and removes it from the list of active coroutines
    public void StopCoroutine(Coroutine coroutine)
    {
        base.StopCoroutine(coroutine);
        _activeCoroutines.Remove(coroutine);
    }

    // Stops all active coroutines
    public void StopAllCoroutines()
    {
        foreach (Coroutine coroutine in _activeCoroutines)
        {
            base.StopCoroutine(coroutine);
        }
        _activeCoroutines.Clear();
    }
}



// HOW TO CALL THE CORUTINE
// CoroutineManager.Instance.StartCoroutine(MyCoroutine());
*/