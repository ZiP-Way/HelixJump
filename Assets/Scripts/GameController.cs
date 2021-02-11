using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject restartMenu;
    private ScoreSystem scoreSystem;

    private void Awake()
    {
        scoreSystem = GetComponent<ScoreSystem>();
    }

    public void DisableRestartPanel()
    {
        restartMenu.SetActive(false);
        Time.timeScale = 1;

        SceneManager.LoadScene("SampleScene");
    }

    public void EnableRestartPanel(bool isSetNextWave)
    {
        if (isSetNextWave)
        { // If the wave was completed, set the next wave
            scoreSystem.UpdateWave();
        }

        restartMenu.SetActive(true);
        scoreSystem.UpdateBestScore();

        Time.timeScale = 0;
    }
}
