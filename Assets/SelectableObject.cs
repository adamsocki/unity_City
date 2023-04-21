using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectableObject : MonoBehaviour
{
    public UnityEvent OnMouseOverObject;
    public UnityEvent OnMouseSelectObject;

    public DebugManager DebugManager;

    [HideInInspector]
    public bool isSelected = false;

    public void MouseOver()
    {
        if (!isSelected)
        {
            OnMouseOverObject.Invoke();
           // DebugManager.PrintError();
        }
    }

    public void MouseSelect()
    {
        isSelected = true;
        OnMouseSelectObject.Invoke();
    }

    public void MouseExit()
    {
        isSelected = false;
    }
}
