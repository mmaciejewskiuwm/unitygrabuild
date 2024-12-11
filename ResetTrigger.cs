using UnityEngine;

public class ResetTrigger : MonoBehaviour
{
    public Transform ballStartPosition; 
    public ScoreManager scoreManager; 
    public Transform objectToTeleport;
    public Vector3 objectTargetPosition; 
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D ballRigidbody = collision.GetComponent<Rigidbody2D>();
            if (ballRigidbody != null)
            {
                ballRigidbody.velocity = Vector2.zero;
            }
            collision.transform.position = ballStartPosition.position;


            if (objectToTeleport != null)
            {
                objectToTeleport.position = objectTargetPosition;
            }

            if (gameManager != null)
            {
                gameManager.LoseLife();
            }
        }
    }
}
