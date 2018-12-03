using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatTooltip : MonoBehaviour 
{

	public Image icon;
	public Transform blockTransform;
	private Image[] blocks;	
	private ResourceType type;
	public ResourceSpriteDictionary spriteDictionary;
	public CubePoolController cubePool;
	public ResourceUI resourceUI;

	// Use this for initialization
	public void Start () 
	{
		blocks = blockTransform.GetComponentsInChildren<Image>();
	}

	public void Set(CardStat stat)
	{
		type = stat.type;
		Sprite iconSprite = spriteDictionary.GetIcon(stat.type);
		Sprite blockSprite = (stat.value > 0) ? spriteDictionary.GetBlock(stat.type) : spriteDictionary.GetNegative(stat.type);

		icon.sprite = iconSprite;
		icon.enabled = true;
	
		int absVal = Mathf.Abs(stat.value);
		for(int i = 0; i < blocks.Length; i++)
		{
			blocks[i].sprite = blockSprite;
			blocks[i].enabled = i < absVal;
		}
	}

	public void Clear()
	{
		icon.enabled = false;
		foreach(Image block in blocks)
		{
			block.enabled = false;
		}
	}

	public void RequestLaunches()
	{
		foreach(Image block in blocks)
		{
			if(block.enabled) 
			{
				Sprite tempSprite = block.sprite;
				Vector3 tempPosition = block.transform.position;
				Vector3 targetPosition = resourceUI.GetCubeTarget(type);
				cubePool.RequestLaunch(block.sprite, tempPosition, targetPosition);
			}
		}
	}
	
}
