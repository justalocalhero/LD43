using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour 
{

	public TextMeshProUGUI mesh;
	private Vector3 target;
	private Vector3 velocity;
	private float lifetime;

	public void Update()
	{
		mesh.transform.localPosition = Vector3.SmoothDamp(mesh.transform.localPosition, target, ref velocity, lifetime);
		lifetime -= Time.deltaTime;
	}

	public void Launch(string text, Vector3 startPosition, float lifetime)
	{
		mesh.transform.localPosition = startPosition;
		this.target = Vector3.zero;
		this.lifetime = lifetime;
		mesh.SetText(text);
	}
}
