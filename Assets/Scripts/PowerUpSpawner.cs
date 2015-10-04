using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour {

	public GameObject[] powerups;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(Spawn());
	}
	
	// Update is called once per frame
	IEnumerator Spawn () 
	{
		while (true) 
		{
			yield return new WaitForSeconds (5);
			int randNum = Random.Range (0, 25);
			if (randNum < powerups.Length)
				Instantiate (powerups [randNum], new Vector3 (0, 0, 0), new Quaternion (0, 0, 0, 0));
		}
	}
}
