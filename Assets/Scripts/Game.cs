using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
	public Text scoreText;
	public int scoreLimit;

	int playerScore, aiScore;
	bool gameOver = false;

	public void IncAiScore() {
		aiScore++;
		UpdateScoreText();
		CheckWin();
	}

	public void IncPlayerScore() {
		playerScore++;
		UpdateScoreText();
		CheckWin();
	}

	void UpdateScoreText() {
		scoreText.text = "Player: " + playerScore + " | AI: " + aiScore;
	}

	void CheckWin() {
		if(aiScore == scoreLimit) {
			GameObject.FindGameObjectWithTag("GameController").SendMessage("DisplayText", new Args("AI has won!", 2));
			gameOver = true;
		} else if(playerScore == scoreLimit) {
			GameObject.FindGameObjectWithTag("GameController").SendMessage("DisplayText", new Args("Player has won!", 2));
			gameOver = true;
		}
	}

	void Update() {
		if(gameOver && Input.GetKeyDown(KeyCode.R)) {
			aiScore = playerScore = 0;
			gameOver = false;
		}
	}
}
