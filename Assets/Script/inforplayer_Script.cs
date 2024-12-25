using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inforplayer_Script : MonoBehaviour
{
    public int maxheath = 100;
    public int currentheath;
    private float dieAnimationTime = 0.517f;
    public hp_controll healthBar;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentheath = maxheath;
        healthBar.SetHealth(1.0f);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void TakeDamage( int damage)
    {
        currentheath -= damage;
        Debug.Log("player taked " + damage+" damage");
        float healthPercentage = (float)currentheath / maxheath;
        healthBar.SetHealth(healthPercentage);
        if(currentheath <= 0)
        {
            currentheath = 0;
            animator.SetBool("die", true);
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Player has die !!!");
        StartCoroutine(DestroyAfterDelay());
    }
    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(dieAnimationTime);
        Destroy(gameObject);
    }
}
