using UnityEngine;
using UnityEditor;

public class CustomMenuExample
{
    [MenuItem("My Custom Menu/My Function")]
    public static void MyFunction()
    {
        Debug.Log("My custom function has been called!");
    }
}
