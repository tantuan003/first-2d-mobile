using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class inforplayer_Script : MonoBehaviour
{
    public int maxheath = 100;
    public int currentheath;
    private float dieAnimationTime = 0.517f;
    public Animator animator;
    public hp_controll hp;
    public GameObject panelGameover;

    // Start is called before the first frame update
    void Start()
    {
        currentheath = maxheath;
        panelGameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void TakeDamage(int damage)
    {
        currentheath -= damage;
        Debug.Log("Player took " + damage + " damage");
        hp.TakeDamage(damage);
     

        if (currentheath <= 0)
        {
            currentheath = 0;
            Die();
            panelGameover.SetActive(true);
        }
    }

    void Die()
    {
        Debug.Log("Player has die !!!");
        animator.SetBool("die", true);
        StartCoroutine(DestroyAfterDelay());
    }
    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(dieAnimationTime);
        Destroy(gameObject);
    }
    
}
