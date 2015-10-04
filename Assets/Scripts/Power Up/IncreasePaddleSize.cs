using UnityEngine;
using System.Collections;

public class IncreasePaddleSize : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		GameObject obj;
		if(other.gameObject.GetComponent<BallMemory>().PlayerHitBallLast)
			obj = GameObject.FindGameObjectWithTag("Player");
		else
			obj = GameObject.FindGameObjectWithTag("AI");
		obj.transform.localScale += new Vector3(0.5f, 0.5f, 0);
		StartCoroutine(Reset(obj));
	}

	IEnumerator Reset(GameObject obj)
	{
		yield return new WaitForSeconds(10f);
		obj.transform.localScale -= new Vector3(0.5f, 0.5f, 0);
		Destroy(gameObject);
	}
}
