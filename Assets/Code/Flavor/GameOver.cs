using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour 
{
	public float timer;
	private float currentTimer;
	public TextMeshProUGUI mesh;
	public Resetter resetter;
	public Transform grid;
	public Transform poolerTransform;
	public FloatingTextController floatingText;
	
	public void Start()
	{
		timer = currentTimer;
	}

	public void Update()
	{
		if(currentTimer > 0) currentTimer -= Time.deltaTime;
		if(currentTimer <= 0)
		{
			mesh.enabled = true;
			if(Input.anyKeyDown) 
			{

				resetter.Reset(); 
				FloatingText[] texts = grid.GetComponentsInChildren<FloatingText>();
				foreach(FloatingText text in texts)
				{
					text.transform.SetParent(poolerTransform, false);
					text.gameObject.SetActive(false);
				}
				floatingText.Clear();
			}
		}
	}

	public void Reset()
	{
		currentTimer = timer;
		mesh.enabled = false;
	}
}
