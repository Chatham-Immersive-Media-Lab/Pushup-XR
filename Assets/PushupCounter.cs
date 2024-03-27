using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using TMPro;
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
    private float previousValue;
    public TMP_Text words;

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
                previousValue = pushupCount;

                pushupCount+=1;
                
                if (previousValue != pushupCount)
                {
                    audioSource.PlayOneShot(Boop);
                    Debug.Log("Pushup");
                    words.text = Mathf.Round(pushupCount/2).ToString();
                }
                
                atDownPosition = false;
                atUpPosition = false;
            }   
        }

    }

    IEnumerator GetPositions()
    {
        yield return new WaitForSeconds(17f);
        downPos = head.transform.position.y;
        Instantiate(planePrefab, head.transform.position, quaternion.identity);

        

        yield return new WaitForSeconds(6f);

        upPos = head.transform.position.y;
        Instantiate(planePrefab, head.transform.position, quaternion.identity);


        yield return new WaitForSeconds(1f);

        positionsSet = true;
    }

}