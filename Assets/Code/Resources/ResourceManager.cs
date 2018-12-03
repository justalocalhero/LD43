using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ResourceManager : MonoBehaviour 
{
	public delegate void OnResourceChanged(ResourceType type, int delta, int value);
	public OnResourceChanged onResourceChanged;

	public delegate void OnHighlight(ResourceType type, int delta, int value);
	public OnHighlight onHighlight;

	private int[] resources = new int[Enum.GetNames(typeof(ResourceType)).Length];
	private int[] excess = new int[Enum.GetNames(typeof(ResourceType)).Length];

	public IntReference startingResources;

	private int maxResources;

	public CardLibrary cardLibrary;
	private bool lost = false;
	public GameObject gameOverScreen;
	public GameOver gameOver;
	public TextMeshProUGUI gameOverMesh;
	public FloatingTextController gameOverController;
	private int yearCount = 0;

	public void Start()
	{
		maxResources = startingResources.value;

		for(int i = 0; i < resources.Length; i++)
		{
			resources[i] = startingResources.value;
		}
	}

	public void Reset()
	{
		for(int i = 0; i < resources.Length; i++)
		{
			resources[i] = startingResources.value;
			excess[i] = 0;
			RaiseOnResourceChanged((ResourceType)i, 0, resources[i]);
		}
		lost = false;
		yearCount = 0;
	}

	private void AddResource(ResourceType type, int value)
	{
		if(value == 0) return;
		int index = (int)type;
		int current = resources[index];
		int newValue = current + value;
		if(newValue > maxResources) AddExcess(type, newValue - maxResources); 
		int clampedValue = Mathf.Clamp(current + value, 0, maxResources);
		resources[index] = clampedValue;
		RaiseOnResourceChanged(type, value, newValue);
		if(clampedValue == 0) Lose(type);
	}

	private void AddExcess(ResourceType type, int value)
	{
		excess[(int)type] = excess[(int)type] + value;
		Debug.Log("Excess " + type + " " + excess[(int)type]);
	}

	public void AddResource(int[] values)
	{
		yearCount++;
		for(int i = 0; i < values.Length; i++)
		{
			AddResource((ResourceType)i, values[i]);
		}
	}

	public void AddResource(Card card)
	{
		List<CardStat> stats = card.GetStats();
		
		foreach(CardStat stat in stats)
		{
			AddResource(stat.type, stat.value);
		}
	}

	public void Lose(ResourceType type)
	{
		if(!lost)
		{
			lost = true;
			gameOverScreen.SetActive(true);
			List<string> finalString = cardLibrary.GetMasteryString();
			foreach(string text in finalString)
			{
				gameOverController.RequestLaunch(text);
			}

			gameOverMesh.SetText(GenerateGameOverString(type));
			gameOver.Reset();
		}
	}

	public string GenerateGameOverString(ResourceType deathType)
	{
		string durationString = "After " + NumberToWords(yearCount) + " Years, you ";
		if(yearCount > 50) durationString += " finally ";
		string deathString = "";
		switch(deathType)
		{
			case ResourceType.happiness:
				deathString += "Wallowed away in Misery\n";
				break;
			case ResourceType.social:
				deathString += "Succumbed to Loneliness\n";
				break;
			case ResourceType.success:
				deathString += "Lost Hope\n";
				break;
			case ResourceType.wellness:
				deathString += "Fell Ill\n";
				break;
		}
		string excessString = "";

		int firstCount = 0;

		for(int i = 0; i < excess.Length; i++)
		{
			if(excess[i] > 0 && i != (int)deathType) firstCount++;
		}

		bool shouldComma = firstCount > 2;
		bool shouldAnd = firstCount > 1;

		int secondCount = 0;

		for(int i = 0; i < excess.Length; i++)
		{
			if(excess[i] > 0 && i != (int)deathType)
			{
				secondCount++;
				string current = "";				
				if(secondCount == firstCount && shouldAnd) current += "and ";
				current += "" + NumberToWords(excess[i]) + " excess ";
				switch((ResourceType)i)
				{
					case ResourceType.happiness:
					current += "Leisure";
					break;
				case ResourceType.social:
					current += "Companionship";
					break;
				case ResourceType.success:
					current += "Satisfaction";
					break;
				case ResourceType.wellness:
					current += "Wellness";
					break;
				}				
				current += (secondCount < firstCount && shouldComma) ? ", " : " ";

				excessString += current;
			}
		}

		if(excessString != "") excessString = "You Generated " + excessString;

		
		return durationString + deathString + "<size=14>" + excessString + "</size>";
	}

	public static string NumberToWords(int number)
		{
		if (number == 0)
			return "zero";

		if (number < 0)
			return "minus " + NumberToWords(Math.Abs(number));

		string words = "";

		if ((number / 1000000) > 0)
		{
			words += NumberToWords(number / 1000000) + " million ";
			number %= 1000000;
		}

		if ((number / 1000) > 0)
		{
			words += NumberToWords(number / 1000) + " thousand ";
			number %= 1000;
		}

		if ((number / 100) > 0)
		{
			words += NumberToWords(number / 100) + " hundred ";
			number %= 100;
		}

		if (number > 0)
		{
			if (words != "")
				words += "and ";

			var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
			var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

			if (number < 20)
				words += unitsMap[number];
			else
			{
				words += tensMap[number / 10];
				if ((number % 10) > 0)
					words += "-" + unitsMap[number % 10];
			}
		}

		return words;
	}

	public void RaiseOnResourceChanged(ResourceType type, int delta, int value)
	{
		if(onResourceChanged != null) onResourceChanged(type, delta, value);
	}

	public void RaiseOnHighlight(ResourceType type, int delta, int value)
	{
		if(onHighlight != null) onHighlight(type, delta, value);
	}

	public void Highlight(int[] values)
	{
		for(int i = 0; i < values.Length; i++)
		{
			HighlightResource((ResourceType)i, values[i]);
		}
	}

	private void HighlightResource(ResourceType type, int value)
	{
		int index = (int)type;
		int current = resources[index];

		RaiseOnHighlight(type, value, current);
	}

	public void ClearHighlight()
	{
		int[] temp = {0,0,0,0};

		Highlight(temp);
	}

	
}

public enum ResourceType {wellness, happiness, success, social,}