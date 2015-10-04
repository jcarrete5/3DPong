using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUpdater : MonoBehaviour
{
	public Text scoreText, messageText;

	const int winLimit = 7;
	static int playerScore, aiScore;
	BallSpawner ballSpawner;

	void Start()
	{
		UpdateScore();
		ballSpawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<BallSpawner>();
	}
	
	void UpdateScore()
	{
		scoreText.text = "Player: " + playerScore + " | AI: " + aiScore;
	}

	void DestroyPowerUps()
	{
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

		DestroyPowerUps();
		if(playerScore == winLimit)
		{
			Debug.Log("Player won!");
			messageText.text = "Player Won!";
		}
		else if(aiScore == winLimit)
		{
			Debug.Log("AI won!");
			messageText.text = "AI Won!";
		}
		else
			StartCoroutine(NextRound());
	}

	IEnumerator NextRound()
	{
		yield return new WaitForSeconds(2);
		StartCoroutine(ballSpawner.DelaySpawnBall());
	}
}
