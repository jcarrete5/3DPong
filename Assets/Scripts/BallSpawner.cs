using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour {
	public GameObject ballPrefab;
	public Text messageText;

	void Start() {
		StartCoroutine(DelaySpawnBall());
	}

	public IEnumerator DelaySpawnBall() {
		for(int i = 3; i > 0; i--) {
			messageText.text = i.ToString();
			yield return new WaitForSeconds(1);
		}
		messageText.text = "";
		
		SpawnBall(new Vector3(0, 0, -250));
	}

	public void SpawnBall(Vector3 force) {
		GameObject ball = Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		ball.GetComponent<Rigidbody>().AddForce(force); 
	}
}
