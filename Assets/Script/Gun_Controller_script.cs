using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun_Controller_script : MonoBehaviour
{
    public Transform gunTransform;
    public Joystick joystick;
    private Vector3 originalScale;
    public GameObject BulletPrefab;
    public float bulletspeed = 10;
    public Button firebutton;
    public GameObject muzzle;
    public float muzzletime = 0.1f;
    private void Start()
    {
        originalScale = transform.localScale;
        firebutton.onClick.AddListener(triggershoot);
       
    }

    void Update()
    {
        // Lấy giá trị từ Joystick
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        // Tính toán góc quay
        Vector2 direction = new Vector2(horizontal, vertical);

        // Xoay súng theo hướng joystick
        if (direction.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            gunTransform.rotation = Quaternion.Euler(0, 0, angle);
        }

        // Kiểm tra hướng di chuyển của nhân vật (hướng Joystick)
        if (direction.x > 0.1f)
        {
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
        }
        else if (direction.x < -0.1f)
        {

            transform.localScale = new Vector3(-originalScale.x, -originalScale.y, originalScale.z);
        }
    }
    IEnumerator shoot()
    {
        muzzle.SetActive(true);
        yield return new WaitForSeconds(muzzletime);
        muzzle.SetActive(false);
        GameObject bullet = Instantiate(BulletPrefab, gunTransform.position, gunTransform.rotation);
        Vector2 shootingDirection = gunTransform.right;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = shootingDirection * bulletspeed;
        }
        Destroy(bullet, 7);
    }
    void triggershoot()
    {
        StartCoroutine(shoot());
    }
}
