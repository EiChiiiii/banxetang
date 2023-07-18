using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab của viên đạn
    public float bulletForce = 5f;  // Lực bắn viên đạn
    public float recoilForce = 3f;   // Lực đẩy lùi
    public Transform FirePos;
    public float TimeBtwFire;
    private float timeBtwFire;
    void Update()
    {
        timeBtwFire -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timeBtwFire < 0)  // Khi nhấn nút Fire1 (ví dụ: chuột trái)
        {
            Shoot();  // Gọi hàm bắn đạn
            Recoil(); // Gọi hàm đẩy lùi
        }
        // Lấy vị trí chuột trong không gian màn hình
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // Tính toán vector hướng từ người chơi tới vị trí chuột
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        
        // Chuyển đổi vector hướng thành góc quay
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        // Xoay người chơi theo góc quay
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }
    void Shoot()
    {
        timeBtwFire = TimeBtwFire;

        GameObject bullet = Instantiate(bulletPrefab, FirePos.position, FirePos.rotation);  // Tạo viên đạn mới từ prefab
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();  // Lấy component RigidBody2D của viên đạn
        
        rb.AddForce(FirePos.up * bulletForce, ForceMode2D.Impulse);  // Bắn viên đạn theo hướng "up" của người chơi
    }

    void Recoil()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();  // Lấy component RigidBody2D của người chơi

        rb.AddForce(-FirePos.up * recoilForce, ForceMode2D.Impulse);  // Đẩy lùi người chơi theo hướng "down"
    }
}
