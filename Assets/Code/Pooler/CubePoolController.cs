using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePoolController : MonoBehaviour 
{
	public ObjectPooler cubePool;
	private Queue<LaunchRequest> requests = new Queue<LaunchRequest>();
	public float maxTimer = .1f;
	public float timer = 0.0f;
	public float lifetime = .25f;
	

	public void Update()
	{
		if(requests.Count > 0)
		{
			timer -= Time.deltaTime;
			if(timer <= 0) Launch(requests.Dequeue());
		}
	}

	public void RequestLaunch(Sprite sprite, Vector3 start, Vector3 target)
	{
		Sprite tempSprite = sprite;
		Vector3 tempStart = new Vector3(start.x, start.y, start.z);
		Vector3 tempTarget = new Vector3(target.x, target.y, target.z);

		requests.Enqueue(new LaunchRequest {
			sprite = tempSprite,
			start = tempStart,
			target = tempTarget,
		});
	}

	private void Launch(LaunchRequest request)
	{
		cubePool.Get().GetComponent<FloatingCube>().Launch(request.sprite, request.start, request.target, lifetime);
		if(requests.Count > 0) timer = maxTimer;
	}
}

public struct LaunchRequest {public Sprite sprite; public Vector3 start; public Vector3 target;};