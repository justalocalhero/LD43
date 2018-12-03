using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceUI : MonoBehaviour 
{
	private ResourceUISlot[] slots;
	public ResourceManager resourceManager;
	public IntReference startingResources;

	// Use this for initialization
	void Start () {
		slots = GetComponentsInChildren<ResourceUISlot>();
		for(int i = 0; i < slots.Length; i++)
		{
			slots[i].SetType((ResourceType)i);
			UpdateSlot((ResourceType)i, startingResources.value, startingResources.value);
		}
		resourceManager.onResourceChanged += UpdateSlot;
		resourceManager.onHighlight += HighlightSlot;


	}

	public void UpdateSlot(ResourceType type, int delta, int value)
	{
		slots[(int)type].SetValue(value);
	}

	public void HighlightSlot(ResourceType type, int delta, int value)
	{
		slots[(int)type].Highlight(value, delta);
	}

	public Vector3 GetCubeTarget(ResourceType type)
	{
		return slots[(int)type].cubeTarget.position;
	}
}
