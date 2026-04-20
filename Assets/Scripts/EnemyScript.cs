using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    public float minWaitTime = 1f;
    public float maxWaitTime = 3f;

    private Transform targetPoint;
    private bool isWaiting = false;

    void Start()
    {
        targetPoint = pointB;
    }

    void Update()
    {
        if (isWaiting) return;

        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPoint.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            StartCoroutine(WaitAndSwitch());
        }
    }

    IEnumerator WaitAndSwitch()
    {
        isWaiting = true;

        float waitTime = Random.Range(minWaitTime, maxWaitTime);
        yield return new WaitForSeconds(waitTime);

        targetPoint = (targetPoint == pointA) ? pointB : pointA;

        Flip();

        isWaiting = false;
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
