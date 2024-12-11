using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public int scoreValue = 10;
    public float bounceForce = 500f;
    private ScoreManager scoreManager;
    private AudioSource audioSource;
    public Animator scoreAnimator;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        audioSource = GetComponentInChildren<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (scoreManager != null)
            {
                scoreManager.AddScore(scoreValue);
                if (scoreAnimator != null)
                {
                    scoreAnimator.SetTrigger("Increase");
                }
            }

            Rigidbody2D ballRigidbody = collision.GetComponent<Rigidbody2D>();
            if (ballRigidbody != null)
            {
                Vector2 bounceDirection = (collision.transform.position - transform.position).normalized;
                ballRigidbody.velocity = Vector2.zero;
                ballRigidbody.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
            }

            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
