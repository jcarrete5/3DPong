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
		GameObject.FindGameObjectWithTag("GameController").GetComponent<BallSpawner>().SpawnBall();
	}
}
