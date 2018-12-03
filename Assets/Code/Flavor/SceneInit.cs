using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInit : MonoBehaviour {

	public Card[] cards;

	public void Start()
	{
		foreach(Card card in cards)
		{
			card.Reset();
		}
	}
}
