using UnityEngine;
using System.Collections;

public class IncreaseBallSpeed : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		Destroy(gameObject);
		ApplyEffect();
	}
	
	void ApplyEffect()
	{
		GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
		foreach(GameObject ball in balls)
			ball.GetComponent<Rigidbody>().velocity *= 2f;
	}	
}
