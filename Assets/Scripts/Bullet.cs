using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 target;
    private float speed;

    public void Initialize(Vector3 targetPosition, float bulletSpeed)
    {
        target = targetPosition;
        speed = bulletSpeed;
    }

    void Update()
    {
        // 朝目标移动
        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );

        // 到达中心以后删除
        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            Destroy(gameObject);
        }
    }
}