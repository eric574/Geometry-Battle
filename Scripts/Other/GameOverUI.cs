using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour {

	public TextMeshProUGUI highScore;
	public TextMeshProUGUI score;
	public TextMeshProUGUI trashTalk;

	public List<string> trashQuotes;

	public static GameOverUI instance;

	public GameObject newHighScore;
	
	private void Awake() {
		instance = this;
	}

	public void UpdateScore() {
		if (ScoreController.instance.score > ScoreController.instance.highScore) {
			ScoreController.instance.highScore = ScoreController.instance.score;
			newHighScore.SetActive(true);
		}
		else newHighScore.SetActive(false);
		score.text = "SCORE: " + ScoreController.instance.score;
		highScore.text = "HIGHSCORE: " + ScoreController.instance.highScore;
		trashTalk.text = trashQuotes[Random.Range(0, trashQuotes.Count)];
	}

}
