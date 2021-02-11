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

    public void EnableRestartPanel()
    {
        restartMenu.SetActive(true);
        scoreSystem.UpdateBestScore();

        Time.timeScale = 0;
    }
}
