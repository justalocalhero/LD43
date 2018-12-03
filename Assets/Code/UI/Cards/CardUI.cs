using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour 
{
	public CardManager cardManager;

	public void Drop(int drag, int drop)
	{
		cardManager.Drop(drag, drop);
	}

	public void Highlight(int drag, int drop)
	{
		cardManager.Highlight(drag, drop);
	}

	public void ClearHighlight()
	{
		cardManager.ClearHighlight();
	}

	public int CalculateDropIndex(float x)
	{
		return -1;
	}
}
