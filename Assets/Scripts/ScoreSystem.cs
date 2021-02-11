using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private Text scoreTxt;
    [SerializeField] private Text bestScoreTxt;

    private int amountOfScore;

    private void Awake()
    {
        amountOfScore = 0;
        bestScoreTxt.text = "Best:" + PlayerPrefs.GetInt("Highscore").ToString();
    }

    public void UpdateScore(int scoreValue)
    {
        amountOfScore += scoreValue;
        scoreTxt.text = amountOfScore.ToString();
    }
    public void UpdateBestScore()
    {
        int bestScore;
        int.TryParse(bestScoreTxt.text, out bestScore);

        if (amountOfScore > bestScore)
        {
            bestScoreTxt.text = "Best:" + amountOfScore.ToString();
            PlayerPrefs.SetInt("Highscore", amountOfScore);
        }
    }
}
