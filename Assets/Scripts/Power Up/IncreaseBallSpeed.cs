using UnityEngine;
using System.Collections;

public class IncreaseBallSpeed : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		transform.position = new Vector3(100, 0, 0);
		GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
		foreach(GameObject ball in balls)
		{
			ball.GetComponent<Rigidbody>().velocity *= 2f;
		}
		StartCoroutine(Reset(balls));
	}

	IEnumerator Reset(GameObject[] balls)
	{
		yield return new WaitForSeconds(10f);
		foreach(GameObject ball in balls)
			ball.GetComponent<Rigidbody>().velocity /= 2f;
		Destroy(gameObject);
	}
}
