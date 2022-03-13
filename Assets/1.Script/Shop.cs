using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
public class Shop : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private Transform cam;
    float temp;

    public void OnBeginDrag(PointerEventData eventData)
    {
        temp = eventData.position.x;
    }

    public void OnDrag(PointerEventData eventData)
    {
        cam.Rotate(new Vector3(0, -(temp - eventData.position.x) * Time.deltaTime * 10, 0));//(-((temp - eventData.position.x) * Time.deltaTime));
        temp = eventData.position.x;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        temp = 0;
    }
}
