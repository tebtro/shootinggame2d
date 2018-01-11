using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text ScoreGUI;
    public Text HighscoreGUI;

    private int score;
    private int highscore;
    private string scoreText = "Score: ";
    private string highscoreText = "Highscore: ";
    private string highScoreKey = "HighScoreKey";

    // Use this for initialization
    void Start () {
        Initialize();
	}

    public void Initialize()
    {
        score = 0;
        highscore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    // Update is called once per frame
    void Update () {
        if (highscore < score) highscore = score;
        ScoreGUI.text = scoreText + score.ToString();
        HighscoreGUI.text = highscoreText + highscore.ToString();
	}

    public void AddPoints(int points)
    {
        score += points;
    }

    public void Save()
    {
        PlayerPrefs.SetInt(highScoreKey, highscore);
        PlayerPrefs.Save();

        Initialize();
    }
}
