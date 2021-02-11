using UnityEngine;

public class MapScroll : MonoBehaviour
{
    private Vector3 lastTapPos;

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 curTapPos = Input.mousePosition;

                if (lastTapPos == Vector3.zero)
                {
                    lastTapPos = curTapPos;
                }
                float delta = lastTapPos.x - curTapPos.x;
                lastTapPos = curTapPos;

                transform.Rotate(Vector3.up * delta);
            }

            if (Input.GetMouseButtonUp(0))
            {
                lastTapPos = Vector3.zero;
            }
        }
    }

}
