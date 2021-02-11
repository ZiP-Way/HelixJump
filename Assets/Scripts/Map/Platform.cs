using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private bool isFirstPlatform;
    [SerializeField] private bool isLastPlatform;

    [Header("Materials")]
    [SerializeField] private Material dangerousPartMat;
    [SerializeField] private Material lastPlatformMat;

    private int rndIndexOfPart;
    private int minValue;

    private void Start()
    {
        if (isLastPlatform)
        {
            SetLastPlatform();
            return;
        }

        minValue = isFirstPlatform ? 1 : 0;

        SetHole();
        SetDangerousPart();
    }

    private void SetHole()
    {
        rndIndexOfPart = Random.Range(minValue, transform.childCount);

        transform.GetChild(rndIndexOfPart).gameObject.SetActive(false); // disable one random part of the platform
    }

    private void SetDangerousPart()
    {
        rndIndexOfPart = Random.Range(minValue, transform.childCount);

        transform.GetChild(rndIndexOfPart).gameObject.GetComponent<Renderer>().material = dangerousPartMat;
        transform.GetChild(rndIndexOfPart).gameObject.tag = "DangerousPart";
    }

    private void SetLastPlatform()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Renderer>().material = lastPlatformMat;
        }
    }
}
