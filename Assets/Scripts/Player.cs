using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; //左右移動の速度
    public float jumpForce = 7f; //ジャンプ力
    private Rigidbody2D rb;
    private bool isGrounded = true; //地面に接しているか

    public float Movementrange = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        //現在の縦速度を維持しつつ、横方向だけ変更
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        //地面にいたらジャンプできる
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