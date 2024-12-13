using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dame_bullet_Script : MonoBehaviour
{
    public int damge = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            infor_enemy_Script health =collision.GetComponent<infor_enemy_Script>();
            health.TakeDamage(damge);
            Destroy(gameObject);
        }
    }
}
