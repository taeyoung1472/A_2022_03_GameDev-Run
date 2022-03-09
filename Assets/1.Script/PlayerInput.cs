using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
public class PlayerInput : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private PlayerControll playerControll;
    float temp;

    public void OnBeginDrag(PointerEventData eventData)
    {
        temp = eventData.position.x;
    }

    public void OnDrag(PointerEventData eventData)
    {
        playerControll.Controll(-((temp - eventData.position.x) * Time.deltaTime));
        temp = eventData.position.x;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        temp = 0;
    }
}
