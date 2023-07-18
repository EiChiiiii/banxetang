using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab của viên đạn
    public float moveSpeed = 5f;     // Tốc độ di chuyển của enemy
    public float fireRate = 2f;      // Tốc độ bắn đạn (số giây giữa các lần bắn)
    private Transform player;        // Tham chiếu đến player
    public float nextFireTime;      // Thời gian kế tiếp có thể bắn đạn

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextFireTime = Time.time;
    }

    void Update()
    {
        MoveTowardsPlayer();
        RotateTowardsPlayer();
        FireBullet();
    }

    void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void RotateTowardsPlayer()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void FireBullet()
    {
        if (Time.time >= nextFireTime)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
}
