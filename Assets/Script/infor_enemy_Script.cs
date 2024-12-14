using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infor_enemy_Script : MonoBehaviour
{
    public int health = 30;
    public Animator animator;
    private float dieAnimationTime = 0.933f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            animator.SetBool("die", true);
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
    void Die()
    {
        Debug.Log("Enemy died");
        animator.SetBool("die", true);
        StartCoroutine(DestroyAfterDelay());
    }
    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(dieAnimationTime);
        Destroy(gameObject);
    }
}
