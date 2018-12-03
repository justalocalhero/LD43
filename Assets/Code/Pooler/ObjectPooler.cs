using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour 
{
	private Queue<GameObject> pool;
	public Transform poolContainer;
	public GameObject objectToPool;
	public int amountToPool;

	public void Start()
	{
		pool = new Queue<GameObject>();

		for(int i = 0; i < amountToPool; i++)
		{
			GameObject obj = (GameObject)Instantiate(objectToPool, poolContainer);
			obj.SetActive(false);
			pool.Enqueue(obj);
		}
	}

	public GameObject Get()
	{
		GameObject obj = pool.Dequeue();
		obj.SetActive(true);
		pool.Enqueue(obj);

		return obj;
		
	}

	public void Clear()
	{
		pool.Clear();
	}
}
