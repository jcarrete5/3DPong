using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public Text scoreText;
	public int scoreLimit;
	int playerScore, aiScore;

	public void UpdateScore(int deltaPlayerScore, int deltaAiScore) {
		playerScore += deltaPlayerScore;
		aiScore += deltaAiScore;
		CheckWin();
	}

	void CheckWin() {

	}


}
