using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_trap : MonoBehaviour
{
    public Transform finalspawn; 
    public GameObject prefabEnemy; 
    private bool hasSpawned = false; 

    void Start()
    {
        hasSpawned = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasSpawned)
        {
            hasSpawned = true; // Đánh dấu đã spawn
            GameObject enemy = Instantiate(prefabEnemy, finalspawn.position, Quaternion.Euler(0, 0, 0));

            // Đảm bảo không bị gắn parent
            enemy.transform.parent = null;          
        }
    }
}
