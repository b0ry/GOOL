using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	private Text scoreBoard;
	private int score = 0;
	// Use this for initialization
	void Start () {
		scoreBoard = gameObject.GetComponent<Text>();
	}

	public void AddToScore (int _score) {
		score += _score;
		int scoreLength = score.ToString().Length;
		string scoreText = "";
		for (int i = scoreLength; i < 10; i++) {
			scoreText += "0";
		}
		scoreBoard.text = "SCORE : " + scoreText + score;
	}
}
