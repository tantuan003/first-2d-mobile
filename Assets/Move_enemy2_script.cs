using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_enemy2_script : MonoBehaviour
{
    public float speed = 3f;
    public Vector3 movedirection = Vector3.left;
    public Transform player;
    private Rigidbody2D rb;
    public Animator animator;
    public int damage = 45;
    public float damageInterval = 1.0f;  // Thời gian giữa mỗi lần gây sát thương (giây)
    private float damageTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }

    }
   void Move()
    {
        rb.velocity = movedirection * speed;
        if(player != null)
        {
            Vector2 directiontoPlayer = (player.position - transform.position).normalized;
            rb.velocity = directiontoPlayer * speed;
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inforplayer_Script player = collision.gameObject.GetComponent<inforplayer_Script>();
            if (player != null && damageTimer <= 0)
            {
                player.TakeDamage(damage); // Gây sát thương
                Debug.Log("Enemy 2 dealt " + damage + " damage continuously!");
                damageTimer = damageInterval; // Reset bộ đếm thời gian
            }
        }
    }
    void Die()
    {
        animator.SetBool("died", true);
        Destroy(gameObject);
        Debug.Log("Enemy 2 dead");
    }
}
