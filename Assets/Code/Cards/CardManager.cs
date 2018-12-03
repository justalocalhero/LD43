using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour 
{
	private Card[] cards;
	public ResourceManager resourceManager;
	public Deck deck;
	public CardPoolController cardPooler;
	
	public void Start()
	{
		cards = GetComponentsInChildren<Card>();
	}

	public void Reset()
	{
		foreach(Card card in cards)
		{
			card.Reset();
		}
	}

	public void Drop(int drag, int drop)
	{
		AddExcept(drop);		
		if(!cards[drag].cardStats.IsMastered()) 
		{
			deck.Add(cards[drag].cardStats.Master());
			cardPooler.RequestLaunch(cards[drag]);
		}
		cards[drop].Replace(cards[drag].cardStats);
		cards[drag].ReplaceAnimate(deck.GetNext());
		RequestLaunchesExcept(drop);
	}

	public void Highlight(int drag, int drop)
	{
		resourceManager.Highlight(GetResourcesExcept(drop));
	}

	public void ClearHighlight()
	{
		resourceManager.ClearHighlight();
	}

	public void AddExcept(int index)
	{
		resourceManager.AddResource(GetResourcesExcept(index));
	}

	public void RequestLaunchesExcept(int index)
	{		
		cards[(index + 1) % 3].cardSlot.RequestLaunches();
		cards[(index + 2) % 3].cardSlot.RequestLaunches();
	}

	public int[] GetResourcesExcept(int index)
	{
		List<CardStat> stats1 = cards[(index + 1) % 3].GetStats();
		List<CardStat> stats2 = cards[(index + 2) % 3].GetStats();

		int[] stats = new int[4];

		for(int i = 0; i < stats1.Count; i++)
		{
			stats[(int)stats1[i].type] += stats1[i].value;
		}

		for(int i = 0; i < stats2.Count; i++)
		{
			stats[(int)stats2[i].type] += stats2[i].value;
		}

		return stats;
	}
}
