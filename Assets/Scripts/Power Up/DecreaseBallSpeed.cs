using UnityEngine;
using System.Collections;

public class DecreaseBallSpeed : MonoBehaviour
{
	GameObject[] balls;

	void Start()
	{
		balls = GameObject.FindGameObjectsWithTag("Ball");
	}

	void OnTriggerEnter(Collider other)
	{
		Destroy(gameObject);
		ApplyEffect();
	}

	void ApplyEffect()
	{
		foreach(GameObject ball in balls)
			ball.GetComponent<Rigidbody>().velocity -= new Vector3(100, 100, 100);
	}
}
