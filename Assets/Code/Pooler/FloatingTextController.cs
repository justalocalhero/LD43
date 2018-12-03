using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour {
	public ObjectPooler cubePool;
	public Transform target;
	private Queue<string> requests = new Queue<string>();
	private Vector3 startPosition = new Vector3(0, 500, 0);
	public float maxTimer = .1f;
	public float timer = 0.0f;
	public float lifetime = .5f;
	

	public void Update()
	{
		if(requests.Count > 0)
		{
			timer -= Time.deltaTime;
			if(timer <= 0) Launch(requests.Dequeue());
		}
	}

	public void RequestLaunch(string text)
	{
		requests.Enqueue(text);
	}

	public void Clear()
	{
		requests.Clear();
	}

	private void Launch(string request)
	{
		FloatingText text = cubePool.Get().GetComponent<FloatingText>();
		text.transform.SetParent(target, false);
		text.Launch(request, startPosition, lifetime);
		if(requests.Count > 0) timer = maxTimer;
	}
}