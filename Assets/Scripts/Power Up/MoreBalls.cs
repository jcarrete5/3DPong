using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoreBalls : MonoBehaviour {
	public GameObject ballPrefab;
	Text messageText;

	void Start() {
		messageText = GameObject.FindGameObjectWithTag("MessageText").GetComponent<Text>();
	}
	
	void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
		ApplyEffect();
	}

	IEnumerator FlavorText() {
		messageText.text = "New ball added!";
		yield return new WaitForSeconds(2f);
		messageText.text = "";
	}

	void ApplyEffect() {
		BallSpawner ballSpawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<BallSpawner>();
		Vector3 force = new Vector3(Mathf.Abs(Random.Range(-100, 100))+1, Mathf.Abs(Random.Range(-100, 100))+1, Mathf.Abs(Random.Range(-200, 200))+1);
		ballSpawner.SpawnBall(force);
	}
}
