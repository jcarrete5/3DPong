using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Anything that will update the score has a score updater component
public class ScoreUpdater : MonoBehaviour {
	public Text scoreText, messageText;
	
	const int winLimit = 7;
	static int playerScore, aiScore;
	BallSpawner ballSpawner;
	AudioSource sound;

	void Start() {
		UpdateScore();
		ballSpawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<BallSpawner>();
		sound = GetComponent<AudioSource>();
	}
	
	void UpdateScore() {
		scoreText.text = "Player: " + playerScore + " | AI: " + aiScore;
	}

	void DestroyBalls() {
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Ball"))
			Destroy(obj);
	}

	void OnCollisionEnter(Collision collision) {
		if(CompareTag("PlayerEndZone")) {
			Debug.Log("Player Scored!");
			aiScore++;
		}
		else {
			Debug.Log("AI Scored!");
			playerScore++;
		}
		UpdateScore();

		DestroyBalls();
		if(playerScore == winLimit) {
			messageText.text = "Player Won!";
			sound.PlayOneShot(sound.clip, 0.5f);
		}
		else if(aiScore == winLimit) {
			messageText.text = "AI Won!";
			sound.PlayOneShot(sound.clip, 0.5f);
		}
		else
			StartCoroutine(NextRound());
	}

	IEnumerator NextRound() {
		Debug.Log("Next Round Beginning...");
		yield return new WaitForSeconds(2);
		StartCoroutine(ballSpawner.DelaySpawnBall());
	}
}
