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
			StartCoroutine(Reset(player, player.transform.localScale));
			player.transform.localScale = new Vector3(2, 2, 0);
		}
		else
		{
			GameObject ai = GameObject.FindGameObjectWithTag("AI");
			StartCoroutine(Reset(ai, ai.transform.localScale));
			ai.transform.localScale = new Vector3(2, 2, 0);
		}
	}
	
	IEnumerator Reset(GameObject obj, Vector3 original)
	{
		yield return new WaitForSeconds(20);
		obj.transform.localScale = original;
	}
}
