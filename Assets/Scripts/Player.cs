using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded = true;

    public float Movementrange = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        //Œ»İ‚Ìc‘¬“x‚ğˆÛ‚µ‚Â‚ÂA‰¡•ûŒü‚¾‚¯•ÏX
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        if (isGrounded && (Input.GetKeyDown(KeyCode.Space)))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
            isGrounded = false;
        }

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -Movementrange, Movementrange);
        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}