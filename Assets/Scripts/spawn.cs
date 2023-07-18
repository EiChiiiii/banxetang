using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab của enemy
    public int maxSpawnCount = 5;  // Số lượng enemy tối đa được tạo ra
    public float spawnDelay = 2f;  // Thời gian giữa mỗi lần tạo enemy
    private int currentSpawnCount = 0;  // Số lượng enemy đã được tạo ra

    private void Start()
    {
        // Gọi hàm SpawnEnemy() sau mỗi khoảng thời gian spawnDelay
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnDelay);
    }

    private void SpawnEnemy()
    {
        if (currentSpawnCount >= maxSpawnCount)
        {
            // Đạt tới số lượng enemy tối đa, không tạo thêm enemy nữa
            return;
        }

        // Tạo một instance mới từ prefab của enemy
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        
        // Tăng số lượng enemy đã tạo ra
        currentSpawnCount++;
    }
}
