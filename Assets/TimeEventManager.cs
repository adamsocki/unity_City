using UnityEngine;

public class TimeEventManager : MonoBehaviour
{
    public float timeScale;
    public float hoursPerDay;

    public delegate void TimeEvent();
    public static event TimeEvent OnDayPassed;

    private float currentTime;

    private void Update()
    {
        currentTime += Time.deltaTime * timeScale;
        

        if (currentTime >= hoursPerDay * 3600)
        {
            currentTime -= hoursPerDay * 3600;
            OnDayPassed?.Invoke();
        }
    }
}
