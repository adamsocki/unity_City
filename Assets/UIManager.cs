using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainGameCanvas;
    public GameObject subMenuCanvas;

    public void InitUIManager()
    {
        ShowMainGameCanvas();
    }

    public void ShowMainGameCanvas()
    {
        mainGameCanvas.SetActive(true);
        subMenuCanvas.SetActive(false);
    }

    public void ShowSubMenuCanvas()
    {
        mainGameCanvas.SetActive(false);
        subMenuCanvas.SetActive(true);
    }
}
