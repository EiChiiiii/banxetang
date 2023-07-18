using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;  // Tốc độ di chuyển của viên đạn
    public float bulletLifetime = 2f;  // Thời gian sống của viên đạn

    void Start()
    {
        Destroy(gameObject, bulletLifetime);  // Hủy GameObject sau thời gian sống
    }

    void Update()
    {
        // Di chuyển viên đạn theo hướng "up" của transform
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))  // Kiểm tra va chạm với kẻ địch
        {
            Destroy(collision.gameObject);  // Hủy kẻ địch khi bị bắn trúng
            Destroy(gameObject);  // Hủy viên đạn khi va chạm với kẻ địch
        }
    }
}
