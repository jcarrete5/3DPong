﻿using UnityEngine;
using System.Collections;

public class AddSpin : MonoBehaviour
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
			ball.GetComponent<Rigidbody>().angularVelocity = new Vector3(30, 30, 30);
	}
}
