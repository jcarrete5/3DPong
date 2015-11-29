using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DecreaseBallSpeed : MonoBehaviour {
	Text messageText;

	void Start() {
		messageText = GameObject.FindGameObjectWithTag("MessageText").GetComponent<Text>();
	}

	void OnTriggerEnter(Collider other) {
		StartCoroutine(FlavorText());
		transform.position = new Vector3(100, 0, 0);
		GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
		foreach(GameObject ball in balls)
			ball.GetComponent<Rigidbody>().velocity /= 2f;
		StartCoroutine(Reset(balls));
	}

	IEnumerator FlavorText() {
		messageText.text = "Balls are slower!";
		yield return new WaitForSeconds(2f);
		messageText.text = "";
	}

	IEnumerator Reset(GameObject[] balls) {
		yield return new WaitForSeconds(10f);
		foreach(GameObject ball in balls)
			ball.GetComponent<Rigidbody>().velocity *= 2f;
		messageText.text = "Balls are normal!";
		yield return new WaitForSeconds(2f);
		messageText.text = "";
		Destroy(gameObject);
	}
}
