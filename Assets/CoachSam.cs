using System.Collections;
using UnityEngine;

public class CoachSam : MonoBehaviour
{
    public GameObject objectToInstantiate; // Reference to the GameObject to instantiate
    public Transform spawnPos; // Changed to Transform for easier access to position and rotation
    
    private GameObject instantiatedObject; // Reference to the instantiated GameObject

    void Start()
    {
        // Start the Coroutine to instantiate the object after 5 seconds
        StartCoroutine(SpawnObject(11f));
        
        // Invoke the method to destroy the object after 8 seconds
        Invoke("DestroyObject", 15f);
    }

    void DestroyObject()
    {
        // Check if the instantiated object exists
        if (instantiatedObject != null)
        {
            // Destroy the instantiated object
            Destroy(instantiatedObject);
        }
    }

    IEnumerator SpawnObject(float delay)
    {
        // Wait for specified delay
        yield return new WaitForSeconds(delay);

        // Instantiate the GameObject at spawn position with spawn rotation
        instantiatedObject = Instantiate(objectToInstantiate, spawnPos.position, spawnPos.rotation);
    }
}
