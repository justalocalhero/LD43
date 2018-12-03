using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour 
{

	public CardStats defaultCard;
	public CardStats cardStats;
	public CardUISlot cardSlot;

	public void Reset()
	{
		Replace(defaultCard);
	}

	public void Replace(CardStats newStats)
	{
		cardStats = newStats;
		cardSlot.Set(cardStats);
	}

	public void ReplaceAnimate(CardStats newStats)
	{
		cardStats = newStats;
		cardSlot.SetAnimate(cardStats);
	}

	public List<CardStat> GetStats()
	{
		return cardStats.GetStats();
	}

}
