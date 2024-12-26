using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_script : MonoBehaviour
{
    public GameObject bulletprefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.name);

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player detected!");

            Gun_Controller_script gun_Controller_Script = collision.GetComponentInChildren<Gun_Controller_script>();

            if (gun_Controller_Script != null)
            {
                Debug.Log("Gun_Controller_script found!");
                Debug.Log("Current bullet prefab: " + gun_Controller_Script.BulletPrefab);
                gun_Controller_Script.changeBullet(bulletprefab);
                Debug.Log("Bullet type changed to: " + bulletprefab.name);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Gun_Controller_script not found on Player or its children!");
            }
        }
    }

}
