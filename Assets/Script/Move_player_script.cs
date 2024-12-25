using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move_player_script : MonoBehaviour
{
    public Joystick joystick;
    public float speed = 10;
    private Vector3 originalScale;
    public Button jump_btn;
    public bool isGrounded;
    public Rigidbody2D rb;
    public Animator animator;
    public float jumpForce = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        animator.SetBool("walking", false);
        animator.SetBool("ide", true);
        isGrounded = true;

        // Gán sự kiện nhảy cho nút Jump
        jump_btn.onClick.AddListener(Jump);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // Đổi hướng nhân vật khi di chuyển
        if (direction.x > 0.1f)
        {
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
        }
        else if (direction.x < -0.1f)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }

        // Cập nhật animation
        if (rb.velocity.magnitude == 0)
        {
            animator.SetBool("ide", true);
            animator.SetBool("walking", false);
        }
        else
        {
            animator.SetBool("ide", false);
            animator.SetBool("walking", true);
        }    
    }

    // Kiểm tra va chạm với mặt đất
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("player is on Ground");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("player is not on Ground");
        }
    }

    // Hàm nhảy
    public void Jump()
    {
        if (isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Debug.Log("jump!!!");
        }
    }
}
