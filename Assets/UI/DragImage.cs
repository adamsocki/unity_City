using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragImage : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Vector3 initialPosition;
    public bool isInTemplatePosition;
    public DropImage dropImageSlot;
    public bool isArchived;
    public int archiveIndex;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        //initialPosition = transform.localPosition;
        isInTemplatePosition = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
       // CheckValidDropLocation(eventData);
    
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CheckValidDropLocation(eventData);
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }

    private void CheckValidDropLocation(PointerEventData eventData)
    {

        if (eventData.pointerCurrentRaycast.gameObject == null)
        {
            rectTransform.anchoredPosition = initialPosition;
            Debug.Log("Not over a valid object");
            return;
        }

        DropImage dropImage = eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<DropImage>();
        if (dropImage.isArchiver)
        {
            return;
        }

        //if (eventData.pointerCurrentRaycast.gameObject.GetType() != typeof(DropImage))
        //{
        //    rectTransform.anchoredPosition = initialPosition;
        //    Debug.Log("not dropimage");
        //    return; 
        //}
        if (dropImage == null)
        {
            rectTransform.anchoredPosition = initialPosition;
            Debug.Log("not dropimage");
            return;
        }
        else
        {
            isInTemplatePosition = true;
            initialPosition = dropImage.transform.localPosition;
            rectTransform.anchoredPosition = initialPosition;
            dropImageSlot = dropImage;
        }
    }
}
