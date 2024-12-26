using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infor_enemy_Script : MonoBehaviour
{
    public int health = 30;
    public Animator animator;
    private float dieAnimationTime = 0.933f;
    public int damage = 30;
    public float damageInterval = 1.0f;  // Thời gian giữa mỗi lần gây sát thương (giây)
    private float damageTimer = 0.0f;    // Bộ đếm thời gian
    private Collider2D enemycollider;
    public bool isSpecialEnemy;
    public GameObject bullet2;
    public Transform spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        enemycollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            animator.SetBool("die", true);
        }
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("enemy taked " + damage + " damage");

        if(health <= 0)
        {
            health = 0;
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Enemy died");
        animator.SetBool("die", true);
        StartCoroutine(DestroyAfterDelay());
    }
    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(dieAnimationTime);
        Vector3 adjustPossion = spawnPosition.position;
        adjustPossion.y -= 1f;
        if (isSpecialEnemy)
        {
            Instantiate(bullet2, adjustPossion, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inforplayer_Script player = collision.gameObject.GetComponent<inforplayer_Script>();
            if (player != null && damageTimer <= 0)
            {
                player.TakeDamage(damage); // Gây sát thương
                animator.SetBool("isAttack", true); // Kích hoạt animation tấn công
                Debug.Log("Enemy dealt " + damage + " damage continuously!");
                damageTimer = damageInterval; // Reset bộ đếm thời gian
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isAttack", false);
            Debug.Log("Enemy stopped attacking");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Lấy Collider của đối tượng va chạm
        Collider2D otherCollider = collision.collider;

        // Tắt va chạm giữa các Enemy
        if (otherCollider.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(enemycollider, otherCollider);
        }
    }
}
