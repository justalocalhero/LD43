using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour 
{
	public CardLibrary cardLibrary;
	public CardManager cardManager;
	public ResourceManager resourceManager;
	public GameObject gameOver;

	public void Reset()
	{
		resourceManager.Reset();
		cardLibrary.ResetCards();
		cardManager.Reset();

		gameOver.SetActive(false);
	}
}
