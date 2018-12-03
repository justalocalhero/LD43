using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName="Cards/CardStats")]
public class CardStats : ScriptableObject 
{
	public Sprite sprite;
	public string description;
	public  List<CardStat> stats;
	private List<CardStat> statsToSend = new List<CardStat>();
	public List<CardStats> parents;
	private List<CardStats> nextCards = new List<CardStats>();
	private bool mastered;

	public void OnEnable()
	{
		mastered = false;
		statsToSend = new List<CardStat>();

		foreach(CardStats parent in parents)
		{
			parent.Add(this);
		}

		foreach(CardStat stat in stats)
		{
			if(stat.value != 0) statsToSend.Add(stat);
		}

	}

	public void Reset()
	{
		mastered = false;
	}

	public void Add(CardStats newStats)
	{
		if(nextCards.Contains(newStats)) return;
		nextCards.Add(newStats);
	}

	public List<CardStats> Master()
	{
		mastered = this;
		return GetNext();
	}
	public List<CardStat> GetStats()
	{
		return statsToSend;
	}

	public List<CardStats> GetNext()
	{
		return nextCards;
	}

	public bool IsMastered()
	{
		return mastered;
	}

}


[Serializable]
public struct CardStat {public ResourceType type; public int value;}