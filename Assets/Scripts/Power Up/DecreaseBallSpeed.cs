using UnityEngine;
using System.Collections;

public class DecreaseBallSpeed : MonoBehaviour
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
		{
			ball.GetComponent<Rigidbody>().velocity /= 2f;
			StartCoroutine(Reset(ball.GetComponent<Rigidbody>().velocity*2f));
		}
	}

	IEnumerator Reset(Vector3 oldSpeed)
	{
		GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
		yield return new WaitForSeconds(10);
		foreach(GameObject ball in balls)
		{
			try
			{
				ball.GetComponent<Rigidbody>().velocity = oldSpeed;
			}
			catch(MissingReferenceException e)
			{
				//lol don't give a shit
				Debug.Log("Missing Reference... no biggy --- " + e.Message);
				break;
			}
		}
	}
}
