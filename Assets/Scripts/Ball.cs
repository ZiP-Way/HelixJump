using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private float impulseForce;

    private Rigidbody rigidbody;

    private ScoreSystem scoreSystem;
    private GameController gameController;

    private bool isIgnoreNextCollision;
    private int scoreValue;

    private int amountDestroyedPlatforms;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        scoreSystem = canvas.GetComponent<ScoreSystem>();
        gameController = canvas.GetComponent<GameController>();

        isIgnoreNextCollision = false;
        scoreValue = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        amountDestroyedPlatforms++;

        scoreValue += scoreSystem.Wave;
        scoreSystem.UpdateScore(scoreValue);

        Destroy(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isIgnoreNextCollision) return;
        isIgnoreNextCollision = true;
        StartCoroutine(AllowCollision());

        if (collision.gameObject.transform.parent.CompareTag("LastPlatform"))
        {
            gameController.EnableRestartPanel(true); // set pause and move to next wave
        }

        if (amountDestroyedPlatforms < 3)
        {
            if (collision.gameObject.CompareTag("DangerousPart"))
            {
                gameController.EnableRestartPanel(false); // set pause
            }
        }
        else if(!collision.gameObject.transform.parent.CompareTag("LastPlatform"))
        {
            Destroy(collision.gameObject.transform.parent);
        }

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);

        scoreValue = 0;
        amountDestroyedPlatforms = 0;
    }

    private IEnumerator AllowCollision()
    {
        yield return new WaitForSeconds(0.2f);
        isIgnoreNextCollision = false;
    }
}
