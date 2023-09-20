using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    // Start is called before the first frame update
    static private Text _UI_TEXT;
    static private int _SCORE = 100;

    private Text txtCom;

    void Awake() {
        _UI_TEXT = GetComponent<Text>();

        if(PlayerPrefs.HasKey("HighScore")) {
            _SCORE = PlayerPrefs.GetInt("HighScore");
        }

        PlayerPrefs.SetInt("HighScore", _SCORE);
    }

    static public int SCORE {
        get { return (_SCORE); }
        private set {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);
            _UI_TEXT.text = "High Score: " + value;
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry) {
        if (scoreToTry <= SCORE) return;
        SCORE = scoreToTry;
    }

    [Tooltip("Set this to true to reset the high score")]
    public bool resetHighScoreNow = false;

    private void OnDrawGizmos() {
        if (resetHighScoreNow) {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 0);
            Debug.LogWarning("High Score reset!");
        }
    }
}
