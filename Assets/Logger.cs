using UnityEngine;

public static class Logger
{
    public static bool verboseMode = true; // Set to true to enable verbose logging.

    public static void LogWarning(string message)
    {
        if (verboseMode)
        {
            Debug.LogWarning($"[Warning] {message}");
        }
    }
}
