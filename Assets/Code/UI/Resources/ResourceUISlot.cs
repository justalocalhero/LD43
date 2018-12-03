using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUISlot : MonoBehaviour 
{
	public Transform iconTransform;
	public Transform blockTransform;
	private Image icon;
	private Image[] blocks;
	public ResourceSpriteDictionary spriteDictionary;
	private Sprite blockSprite;
	private Sprite negativeBlockSprite;
	private ResourceType resourceType;
	public Transform cubeTarget;

	public void SetType(ResourceType type)
	{
		resourceType = type;
		icon = iconTransform.GetComponentInChildren<Image>();
		blocks = blockTransform.GetComponentsInChildren<Image>();

		icon.sprite = spriteDictionary.GetIcon(type);

		blockSprite = spriteDictionary.GetBlock(type);
		negativeBlockSprite = spriteDictionary.GetNegative(type);

		for(int i = 0; i < blocks.Length; i++)
		{
			blocks[i].sprite = spriteDictionary.GetBlock(type);
		}
	}

	public void SetValue(int value)
	{
		for(int i = 0; i < blocks.Length; i++)
		{
			if(i < value)
			{
				SetBlock(blocks[i]);
			}
			else
			{
				SetHide(blocks[i]);
			}
		}
	}

	public void Highlight(int value, int delta)
	{
		
		bool isPositive = delta >= 0;
		int full = isPositive ? value : value + delta;
		int ghost = isPositive ? value + delta : value;

		for(int i = 0; i < blocks.Length; i++)
		{
			if(i < full) 
			{
				SetBlock(blocks[i]);
			}
			else if (i < ghost)
			{
				if(isPositive) SetGhost(blocks[i]);
				else SetNegative(blocks[i]);
			}
			else
			{
				SetHide(blocks[i]);
			}
		}
	}

	public void SetHide(Image image)
	{
		image.enabled = false;
	}

	public void SetBlock(Image image)
	{
		image.enabled = true;
		image.sprite = blockSprite;
		SetFull(image);
	}

	public void SetNegative(Image image)
	{
		image.enabled = true;
		image.sprite = negativeBlockSprite;
		SetHalf(image);
	}

	public void SetGhost(Image image)
	{
		image.sprite = blockSprite;
		SetHalf(image);
	}

	public void SetHalf(Image image)
	{
		image.enabled = true;
		Color tempColor = icon.color;
		tempColor.a = .5f;
		image.color = tempColor;
	}

	public void SetFull(Image image)
	{
		image.enabled = true;
		Color tempColor = icon.color;
		tempColor.a = 1;
		image.color = tempColor;
	}


}

