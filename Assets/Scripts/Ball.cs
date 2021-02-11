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
        scoreValue += 5;
        scoreSystem.UpdateScore(scoreValue);

        Destroy(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        scoreValue = 0;
        if (collision.gameObject.CompareTag("DangerousPart") 
            || collision.gameObject.transform.parent.CompareTag("LastPlatform"))
        {
            gameController.EnableRestartPanel();
        }

        if (isIgnoreNextCollision) return;

        isIgnoreNextCollision = true;
        StartCoroutine(AllowCollision());

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);
    }

    private IEnumerator AllowCollision()
    {
        yield return new WaitForSeconds(0.2f);
        isIgnoreNextCollision = false;
    }
}
