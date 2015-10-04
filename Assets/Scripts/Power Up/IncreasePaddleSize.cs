using UnityEngine;
using System.Collections;

public class IncreasePaddleSize : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		Destroy(gameObject);
		ApplyEffect(other);
	}
	
	void ApplyEffect(Collider other)
	{
		if(other.gameObject.GetComponent<BallMemory>().PlayerHitBallLast)
		{
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			player.transform.localScale += new Vector3(0.5f, 0.5f, 0);
		}
		else
		{
			GameObject ai = GameObject.FindGameObjectWithTag("AI");
			ai.transform.localScale += new Vector3(0.5f, 0.5f, 0);
		}
	}
}
