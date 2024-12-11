using UnityEngine;
using System.Collections;

public class TeleportTrigger : MonoBehaviour
{
    public Transform objectToTeleport; 
    public Vector3 targetPosition; 
    public float delay = 1.0f; 

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(TeleportAfterDelay());
        }
    }

    IEnumerator TeleportAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        if (objectToTeleport != null)
        {
            objectToTeleport.position = targetPosition;
        }
    }
}
