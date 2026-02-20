using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float viewRadius = 5f;
    public Transform player;
    public Transform[] patrolPoints;

    private int patrolIndex = 0;
    private bool chasing = false;

    Rigidbody2D rb;

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < viewRadius)
            chasing = true;
        else
            chasing = false;

        if (chasing)
            ChasePlayer();
        else
            Patrol();
    }

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void ChasePlayer()
    {
        Vector2 dir = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
    }

    void Patrol()
    {
        Transform target = patrolPoints[patrolIndex];
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
        }
    }
}
