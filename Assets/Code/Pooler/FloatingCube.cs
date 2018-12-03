using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingCube : MonoBehaviour {

	public Image image;
	private Vector3 target;
	private Vector3 velocity;
	private float lifetime;

	public void Update()
	{
		transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, lifetime);
		lifetime -= Time.deltaTime;
		if(lifetime <= -.1f) gameObject.SetActive(false);
	}

	public void Launch(Sprite sprite, Vector3 startPosition, Vector3 target, float lifetime)
	{
		this.transform.position = startPosition;
		this.target = target;
		this.lifetime = lifetime;
		image.sprite = sprite;
		image.enabled = true;
	}
}
