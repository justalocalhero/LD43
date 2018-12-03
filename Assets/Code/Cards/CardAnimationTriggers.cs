using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimationTriggers : MonoBehaviour 
{
	private CardUISlot slot;
	
	public void Start()
	{
		slot = GetComponentInParent<CardUISlot>();
	}

	public void OnInStart()
	{
		slot.OnInStart();
	}

	public void OnInStop()
	{
		slot.OnInStop();
	}
	
}
