using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PushupCounter : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject planePrefab;
    public GameObject head;
    public float downPos;
    public float upPos;
    private bool atDownPosition = false;
    private bool atUpPosition = false;
    private bool positionsSet;
    public AudioClip Boop;
    public float pushupCount;
    public float counter;
    private float previousValue;

    private void Start()
    {
        StartCoroutine(GetPositions());
        previousValue = pushupCount;
    }

    private void Update()
    {
        if (positionsSet)
        {
            if (!atDownPosition && head.transform.position.y <= downPos + 0.05f)
            {
                atDownPosition = true;
            }

            if (!atUpPosition && head.transform.position.y >= upPos - 0.05f)
            {
                atUpPosition = true;
            }

            if (atDownPosition && atUpPosition)
            {
                pushupCount++;
                Debug.Log("Pushup");
                atDownPosition = false;
                atUpPosition = false;
            }
        }
        CountPushupsAndBeep();
    }

    IEnumerator GetPositions()
    {
        yield return new WaitForSeconds(16f);
        downPos = head.transform.position.y;
        Instantiate(planePrefab, head.transform.position, quaternion.identity);

        

        yield return new WaitForSeconds(6f);

        upPos = head.transform.position.y;
        Instantiate(planePrefab, head.transform.position, quaternion.identity);


        yield return new WaitForSeconds(1f);

        positionsSet = true;
    }

    private void CountPushupsAndBeep()
    {
        counter = pushupCount / 2;
        if (Mathf.Floor(counter) != Mathf.Floor(previousValue))
        {
            // Play the audio clip
            if (Boop != null)
            {
                audioSource.PlayOneShot(Boop);
            }
        }
    }
}