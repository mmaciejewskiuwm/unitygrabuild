using UnityEngine;

public class Launcher : MonoBehaviour
{
    public float maxForce = 1000f; 
    public float minForce = 100f; 
    public float chargeTime = 1f; 
    public float startYPosition = -2f; 
    public float maxYPosition = -3f; 
    public Transform ballStartPosition; 

    private float currentForce;
    private Rigidbody2D ballRigidbody;

    void Start()
    {
        currentForce = minForce;
        transform.localPosition = new Vector3(transform.localPosition.x, startYPosition, transform.localPosition.z);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            float chargeProgress = Mathf.PingPong(Time.time / chargeTime, 1f); 
            currentForce = Mathf.Lerp(minForce, maxForce, chargeProgress);

            transform.localPosition = new Vector3(
                transform.localPosition.x,
                Mathf.Lerp(startYPosition, maxYPosition, chargeProgress),
                transform.localPosition.z
            );
        }
        else if (Input.GetKeyUp(KeyCode.Space)) 
        {
            LaunchBall();
            transform.localPosition = new Vector3(transform.localPosition.x, startYPosition, transform.localPosition.z); 
        }
    }

    private void LaunchBall()
    {
        if (ballRigidbody != null) 
        {
            
            ballRigidbody.velocity = Vector2.up * currentForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            ballRigidbody = collision.GetComponent<Rigidbody2D>();

            
            if (ballRigidbody != null && ballStartPosition != null)
            {
                ballRigidbody.transform.position = ballStartPosition.position;
                ballRigidbody.velocity = Vector2.zero; 
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            ballRigidbody = null;
        }
    }
}
