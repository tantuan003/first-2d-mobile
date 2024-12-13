using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_enemy_Script : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float stopDistance = 5f;
    private Vector3 originalScale;

    void Update()
    {
        if (player != null)
        {
            // Tính khoảng cách giữa kẻ địch và người chơi
            float distance = Vector2.Distance(transform.position, player.position);

            // Nếu khoảng cách lớn hơn stopDistance, di chuyển và xoay hướng
            if (distance > stopDistance)
            {
                // Di chuyển về phía người chơi
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position += (Vector3)direction * speed * Time.deltaTime;
               
            }
            else
            {
                // Ngừng di chuyển khi đến gần Player
                transform.position = transform.position;
            }
        }
    }
    private void Start()
    {
        originalScale = transform.localScale;
    }
}
