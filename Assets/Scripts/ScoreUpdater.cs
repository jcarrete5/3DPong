using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUpdater : MonoBehaviour
{
	public Text scoreText, messageText;
	
	const int winLimit = 7;
	static int playerScore, aiScore;
	BallSpawner ballSpawner;
	AudioSource sound;

	void Start()
	{
		UpdateScore();
		ballSpawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<BallSpawner>();
		sound = GetComponent<AudioSource>();
	}
	
	void UpdateScore()
	{
		scoreText.text = "Player: " + playerScore + " | AI: " + aiScore;
	}

	void DestroyDynamicObjects()
	{
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Ball"))
			Destroy(obj);
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("PowerUp"))
			Destroy(obj);
	}

	void OnCollisionEnter(Collision collision)
	{
		if(CompareTag("PlayerEndZone"))
		{
			Debug.Log("Player Scored!");
			aiScore++;
		}
		else
		{
			Debug.Log("AI Scored!");
			playerScore++;
		}
		UpdateScore();

		DestroyDynamicObjects();
		if(playerScore == winLimit)
		{
			Debug.Log("You won!");
			messageText.text = "Player Won!";
			sound.PlayOneShot(sound.clip, 1f);
		}
		else if(aiScore == winLimit)
		{
			Debug.Log("AI won!");
			messageText.text = "AI Won!";
			sound.PlayOneShot(sound.clip, 1f);
		}
		else
			StartCoroutine(NextRound());
	}

	IEnumerator NextRound()
	{
		Debug.Log("Next Round Beginning...");
		yield return new WaitForSeconds(2);
		StartCoroutine(ballSpawner.DelaySpawnBall());
	}
}
