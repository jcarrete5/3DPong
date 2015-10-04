using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IncreasePaddleSize : MonoBehaviour
{
	Text messageText;

	void Start()
	{
		messageText = GameObject.FindGameObjectWithTag("MessageText").GetComponent<Text>();
	}

	void OnTriggerEnter(Collider other)
	{
		transform.position = new Vector3(100, 0, 0);
		GameObject obj;
		if(other.gameObject.GetComponent<BallMemory>().PlayerHitBallLast)
			obj = GameObject.FindGameObjectWithTag("Player");
		else
			obj = GameObject.FindGameObjectWithTag("AI");
		StartCoroutine(FlavorText(obj.tag));
		obj.transform.localScale += new Vector3(0.5f, 0.5f, 0);
		StartCoroutine(Reset(obj));
	}

	IEnumerator FlavorText(string objTag)
	{
		messageText.text = objTag + " paddle increased!";
		yield return new WaitForSeconds(2f);
		messageText.text = "";
	}

	IEnumerator Reset(GameObject obj)
	{
		yield return new WaitForSeconds(10f);
		obj.transform.localScale -= new Vector3(0.5f, 0.5f, 0);
		messageText.text = obj.tag + " paddle is normal!";
		yield return new WaitForSeconds(2f);
		messageText.text = "";
		Destroy(gameObject);
	}
}
