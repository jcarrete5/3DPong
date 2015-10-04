using UnityEngine;
using System.Collections;

public class MoreBalls : MonoBehaviour
{
	public GameObject ballPrefab;
	
	void OnTriggerEnter(Collider other)
	{
		Destroy(gameObject);
		ApplyEffect();
	}
	
	void ApplyEffect()
	{
		BallSpawner ballSpawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<BallSpawner>();
		ballSpawner.SpawnBall(new Vector3(Mathf.Abs(Random.Range(-100, 100))+1,
		                                  Mathf.Abs(Random.Range(-100, 100))+1,
		                                  Mathf.Abs(Random.Range(-200, 200))+1));
	}
}
