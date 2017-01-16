using UnityEngine;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour
{

	[SerializeField]
	private GameObject enemyPrefab = null;
	[SerializeField]
	private uint maxEnemies = 5;
	[SerializeField]
	private float spawnMaxDeltaTime = 10.0f;
	[SerializeField]
	private float spawnMinDeltaTime = 5.0f;
	[SerializeField]
	private float spawnDecrementTime = 0.5f;

	private List<GameObject> instances;
	private float timer = 0.0f;
	private float currentDeltaTime;

	void Start()
	{
		instances = new List<GameObject>();
		Debug.Assert(enemyPrefab != null);
		Debug.Assert(spawnDecrementTime >= 0.0f);
		Debug.Assert(spawnMinDeltaTime < spawnMaxDeltaTime);
		currentDeltaTime = spawnMaxDeltaTime;
	}

	void Update()
	{
		foreach(GameObject go in instances)
		{
			if(go == null)
			{
				instances.Remove(go);
			}
		}
		if(instances.Count < maxEnemies)
		{
			timer += Time.deltaTime;
		}
		if (timer > currentDeltaTime)
		{
			currentDeltaTime = Mathf.Max(currentDeltaTime - spawnDecrementTime, spawnMinDeltaTime);
			timer = 0.0f;
			GameObject newInstance = Instantiate<GameObject>(enemyPrefab);
			newInstance.transform.position = transform.position;
			newInstance.transform.rotation = transform.rotation;
			newInstance.transform.localScale = transform.localScale;
			instances.Add(newInstance);
		}
	}
}
