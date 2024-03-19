using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PushupCounter : MonoBehaviour
{
    public GameObject planePrefab;
    public GameObject head;
    public float downPos;
    public float upPos;
    private bool atDownPosition = false;
    private bool atUpPosition = false;
    private bool positionsSet;

    public int pushupCount;
    private void Start()
    {
        StartCoroutine(GetPositions());
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
                pushupCount /= 2; //BAD DUMB STUPID BAD
                Debug.Log("Pushup");
                atDownPosition = false;
                atUpPosition = false;
            }
        }
    }

    IEnumerator GetPositions()
    {
        yield return new WaitForSeconds(10f);
        
        Debug.Log("Press space to set low position");
        
        yield return new WaitForSeconds(5f);
        
        downPos = head.transform.position.y;
        Instantiate(planePrefab, head.transform.position, quaternion.identity);
            
   
        
        Debug.Log("Press space to set high position");
        
        yield return new WaitForSeconds(5f);

        upPos = head.transform.position.y;
        Instantiate(planePrefab, head.transform.position, quaternion.identity);
        
        
        yield return new WaitForSeconds(1f);

        positionsSet = true;
        Debug.Log("Positions set successfully");
    }
}