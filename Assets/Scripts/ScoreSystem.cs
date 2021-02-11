using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private Text waveTxt;
    [SerializeField] private Text scoreTxt;
    [SerializeField] private Text bestScoreTxt;

    public int Wave { get { return curWave; } }
    private int curWave;

    private GameController gameController;

    private int amountOfScore;

    private void Awake()
    {
        gameController = GetComponent<GameController>();

        amountOfScore = 0;
        bestScoreTxt.text = "Best:" + PlayerPrefs.GetInt("Highscore").ToString();

        curWave = PlayerPrefs.GetInt("Wave");
        if(curWave == 0)
        { // if this is the first run of the game, set 1 wave
            curWave = 1;
            PlayerPrefs.SetInt("Wave", curWave);
        }
        waveTxt.text = "Wave: " + curWave.ToString();
    }

    public void UpdateWave()
    {
        curWave++;
        waveTxt.text = "Wave: " + curWave.ToString();
        PlayerPrefs.SetInt("Wave", curWave);
    }

    public void UpdateScore(int scoreValue)
    {
        amountOfScore += scoreValue;
        scoreTxt.text = amountOfScore.ToString();
    }
    public void UpdateBestScore()
    {
        if (amountOfScore > PlayerPrefs.GetInt("Highscore"))
        {
            bestScoreTxt.text = "Best:" + amountOfScore.ToString();
            PlayerPrefs.SetInt("Highscore", amountOfScore);
        }
    }
}
