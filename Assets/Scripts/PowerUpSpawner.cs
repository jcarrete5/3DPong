using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour {

	public Transform boundary; 
	public GameObject[] powerups;

	void Start() 
	{
		StartCoroutine(Spawn());
	}

	IEnumerator Spawn() 
	{
		while(true) 
		{
			yield return new WaitForSeconds(5);
			int randNum = Random.Range(0, 15);
			if(randNum < powerups.Length)
			{
				Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
				Instantiate(powerups[randNum], spawnPosition, Quaternion.identity);
			}
		}
	}
}
