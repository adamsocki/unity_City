using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomUIController : MonoBehaviour
{

   /* public TimeManager timeManager;

    // Update is called once per frame
    public void UpdateUI()
    {
        // Call the OnGUI method to update the custom UI elements
        //RenderGUI();
    }
    GUIStyle customStyle;

    void OnGUI()
    {
        if (customStyle == null)
        {
            customStyle = new GUIStyle(GUI.skin.label);
            customStyle.fontSize = 20;
            customStyle.normal.textColor = Color.red;
            customStyle.alignment = TextAnchor.MiddleCenter;
        }

        GUILayout.Label("Custom Style Example", customStyle);
        GUI.Label(new Rect(10, 10, 100, 20), "Time: " + timeManager.GetFormattedTime());

        if (GUI.Button(new Rect(10, 40, 100, 20), "Increase Time"))
        {
            timeManager.timeScale += 0.5f;
        }

        if (GUI.Button(new Rect(10, 70, 100, 20), "Decrease Time"))
        {
            timeManager.timeScale -= 0.5f;
        }

        if (GUI.Button(new Rect(10, 100, 100, 20), "Pause Time"))
        {
            timeManager.timeScale = 0f;
        }
    }*/

}
