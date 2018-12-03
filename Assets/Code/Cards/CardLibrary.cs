using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Cards/CardLibrary")]
public class CardLibrary : ScriptableObject 
{

	public List<CardStats> cardStats;
	public Color successColor;
	public Color failColor;

	public List<string> GetMasteryString()
	{
		List<string> toReturn = new List<string>();

		foreach(CardStats stats in cardStats)
		{	
			if(stats.IsMastered())
			{
				string current  = "<color=#" + ColorUtility.ToHtmlStringRGB(successColor) + ">";
				current += stats.description + "</color>\n";

				toReturn.Add(current);
			}
		}

		foreach(CardStats stats in cardStats)
		{	
			if(!stats.IsMastered())
			{
				string current  = "<color=#" + ColorUtility.ToHtmlStringRGB(failColor) + ">Never ";
				current += stats.description + "</color>\n";

				toReturn.Add(current);
			}
		}

		return toReturn;
	}

	public void ResetCards()
	{
		foreach(CardStats stats in cardStats)
		{
			stats.Reset();
		}
	}
}
