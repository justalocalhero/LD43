using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName="Resources/SpriteDictionary")]
public class ResourceSpriteDictionary : ScriptableObject
{
	public ResourceSprites[] resourceSprites;

	public Sprite GetIcon(ResourceType type)
	{
		return resourceSprites[(int)type].icon;
	}

	public Sprite GetBlock(ResourceType type)
	{
		return resourceSprites[(int)type].block;
	}

	public Sprite GetNegative(ResourceType type)
	{
		return resourceSprites[(int)type].negativeBlock;
	}
}

[Serializable]
public struct ResourceSprites { public ResourceType type; public Sprite icon; public Sprite block; public Sprite negativeBlock;}