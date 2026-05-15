using UnityEngine;

public class SealPatrol : MonoBehaviour
{
    public float speed = 2f;
    public bool movingRight = true;

    public Transform groundCheck;
    public float checkDistance = 1f;
    public LayerMask groundLayer;

   private  void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * (movingRight ? 1 : -1));
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, checkDistance, groundLayer);

        if (!groundInfo.collider)
        {
            Flip();
        }
    }

    private void Flip()
    {
        movingRight = !movingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
        }
    }
}