using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_Enemy3_0 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb != null)
        {
            Vector2 moveDirection = Vector2.right;
            rb.velocity = moveDirection * speed; // Thiết lập vận tốc
        }
    }
}
