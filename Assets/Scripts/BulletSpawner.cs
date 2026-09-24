using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float spawnRadius = 8f;
    public float bulletHeight = 0.6f;

    public float bulletSpeed = 4f;
    public float spawnInterval = 1.5f;

    private float timer;

    private float[] angles =
    {
        -15f,
        -5f,
         5f,
         15f
    };

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnBullet();
            timer = 0f;
        }
    }

    void SpawnBullet()
    {
        // 随机 D/F/J/K 中的一条轨道
        int lane = Random.Range(0, 4);

        float rad =
            angles[lane] * Mathf.Deg2Rad;

        Vector3 direction = new Vector3(
            Mathf.Sin(rad),
            0,
            Mathf.Cos(rad)
        );

        // 外圈生成位置
        Vector3 spawnPosition =
            direction * spawnRadius;

        spawnPosition.y = bulletHeight;

        GameObject bulletObject =
            Instantiate(
                bulletPrefab,
                spawnPosition,
                Quaternion.identity
            );

        Bullet bullet =
            bulletObject.GetComponent<Bullet>();

        // 球心位置
        Vector3 target =
            new Vector3(
                0,
                bulletHeight,
                0
            );

        bullet.Initialize(
            target,
            bulletSpeed
        );
    }
}