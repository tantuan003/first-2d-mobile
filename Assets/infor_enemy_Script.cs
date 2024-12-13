using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infor_enemy_Script : MonoBehaviour
{
    public int health = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Destroy(gameObject);
    }
}
