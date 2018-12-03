using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDragManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{ 
	private Image image;
	public Transform ghost;
	private float offsetX = 0;
	public Transform clampLeftTransform;
	public Transform clampRightTransform;
	private float clampLeft;
	private float clampRight;
	public CardUI cardUI;

	public void Start()
	{
		image = GetComponentInChildren<Image>();
		clampLeft = clampLeftTransform.position.x;
		clampRight = clampRightTransform.position.x;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		image.raycastTarget = false;
		image.transform.SetParent(ghost);
		ghost.transform.position = transform.position;
		var mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		offsetX = transform.position.x - mousePosition.x;
	}

	public void OnDrag(PointerEventData eventData)
	{
		var mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		mousePosition.z = 0;
		mousePosition.y = transform.position.y;
		mousePosition.x += offsetX;
		mousePosition.x = Mathf.Clamp(mousePosition.x, clampLeft, clampRight);
		image.transform.position = mousePosition;

	}

	public void OnEndDrag(PointerEventData eventData)
	{
		image.raycastTarget = true;
		image.transform.SetParent(transform);
		image.transform.localPosition = Vector3.zero;
		offsetX = 0;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if(eventData.dragging) 
		{
			CardUISlot dropSlot = eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<CardUISlot>();			
			CardUISlot dragSlot = eventData.pointerDrag.GetComponentInParent<CardUISlot>();
			if(dropSlot != null && dragSlot != null) 
			{
				int dragIndex = dragSlot.index;
				int dropIndex = dropSlot.index;
				if(dropIndex - dragIndex > 1) dropIndex--;
				if(dropIndex - dragIndex <-1) dropIndex++;
				cardUI.Highlight(dragIndex, dropIndex);
			}
		}
	}

    public void OnPointerExit(PointerEventData eventData)
    {
		if(eventData.dragging) 
		{
			cardUI.ClearHighlight();
		}
    }
}