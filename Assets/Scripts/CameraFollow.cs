using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private Vector3 lastPos;

    private void Awake()
    {
        lastPos = ball.transform.position;
    }

    private void FixedUpdate()
    {
        if(ball.transform.position.y < lastPos.y)
        {
            transform.position = new Vector3(transform.position.x, ball.transform.position.y + 3, transform.position.z);
            lastPos = ball.transform.position;
        }
    }
}
