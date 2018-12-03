using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDropManager : MonoBehaviour, IDropHandler
{
	private CardUI cardUI;

	public void Start()
	{
		cardUI = GetComponentInParent<CardUI>();
	}

    public void OnDrop(PointerEventData eventData)
    {
		CardUISlot dropSlot = eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<CardUISlot>();
		CardUISlot dragSlot = eventData.pointerDrag.GetComponentInParent<CardUISlot>();

		if(dropSlot != null && dragSlot != null) 
		{
			int dragIndex = dragSlot.index;
			int dropIndex = dropSlot.index;
			if(dropIndex - dragIndex > 1) dropIndex--;
			if(dropIndex - dragIndex < -1) dropIndex++;
			cardUI.Drop(dragIndex, dropIndex);
		}
        
    }
}
