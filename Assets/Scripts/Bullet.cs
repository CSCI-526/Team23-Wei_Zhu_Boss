using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 target;
    private float speed;
    private bool hasResolved;

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

    private void OnTriggerEnter(Collider other)
    {
        if (hasResolved)
            return;

        if (other.CompareTag("Shield"))
        {
            ResolveHit();
        }
        else if (other.CompareTag("Core"))
        {
            ResolveHit();
            LivesManager.Instance?.LoseLife();
        }
    }

    private void ResolveHit()
    {
        hasResolved = true;
        Destroy(gameObject);
    }
}
