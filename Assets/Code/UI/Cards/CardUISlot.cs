using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUISlot : MonoBehaviour 
{
	public int index;
	private StatTooltip[] stats;
	public Card card;
	public Image art;
	public Animator animator;
	public Image Blocker;
	public Transform cardImage;
	public ColorReference HighlightColor;
	public ColorReference DefaultColor;
	private Color dark = new Color(.4f, .4f, .4f, 1);
	private Color light = new Color(1, 1, 1, 1);

	public void Start()
	{
		stats = GetComponentsInChildren<StatTooltip>();
	}

	public void Set(CardStats card)
	{
		List<CardStat> cardStats = card.GetStats();
		art.sprite = card.sprite;
		art.color = (card.IsMastered()) ? dark : light;
		
		for(int i = 0; i < stats.Length; i++)
		{
			if(i < cardStats.Count) stats[i].Set(cardStats[i]);
			else stats[i].Clear();
		}
	}

	public void SetAnimate(CardStats card)
	{
		Set(card);
		animator.Play("in");
	}

	public void OnInStart()
	{
		Blocker.raycastTarget = false;
	}

	public void OnInStop()
	{
		Blocker.raycastTarget = true;
	}

	public void Highlight()
	{

	}

	public void Normal()
	{

	}

	public void Master()
	{
		art.color = dark;
	}

	public void RequestLaunches()
	{
		foreach(StatTooltip stat in stats)
		{
			stat.RequestLaunches();
		}
	}
}
