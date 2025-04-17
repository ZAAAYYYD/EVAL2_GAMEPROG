using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Vitesse & Saut")]
    public float speed = 5f;
    public float jumpForce = 12f;

    Rigidbody2D rb;
    bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Déplacement latéral
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * h * speed * Time.deltaTime);

        // Saut
        if (Input.GetButtonDown("Jump") && isGrounded)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    // Quand tu touches quelque chose...
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (col.gameObject.CompareTag("Obstacle"))
        {
            // là tu triggers le Game Over
            GameManager.Instance.GameOver();
        }
    }

    // Quand tu quittes quelque chose...
    void OnCollisionExit2D(Collision2D col)
    {
        // uniquement pour le sol, pas pour l'obstacle
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
