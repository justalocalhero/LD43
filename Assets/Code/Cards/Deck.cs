using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour 
{
	public List<CardStats> cards;
	public List<CardStats> defaultCards;

	public CardStats GetNext()
	{
		if(cards.Count > 0) {
			int index = GetRandomIndex(cards);
			CardStats toReturn = cards[index];
			cards.RemoveAt(index);
			return toReturn;
		}
		else
		{
			int index = GetRandomIndex(defaultCards);
			return defaultCards[index];
		}
	}

	public void Add(List<CardStats> newStats)
	{
		cards.AddRange(newStats);
	}

	public int GetRandomIndex<T>(List<T> genericList)
	{
		return Mathf.FloorToInt(UnityEngine.Random.Range(0, cards.Count));
	}
}
