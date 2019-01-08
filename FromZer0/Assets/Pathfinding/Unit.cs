using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{


    Vector2[] path;
    int targetIndex;

    public GameObject pc;
    public GameObject startingPosition;
    public Transform target;
    public Rigidbody2D rb;
    [Space]
    public bool aggroed = false;
    [Space]
    [Range(1f, 50f)] public float speed = 20;
    [Range(0.01f, 1f)] public float refreshInterval;
    [Range(0.01f, 10f)] public float minimumDistanceToPlayer = 1.5f;



    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine("RefreshPath");
    }

    private void OnEnable()
    {
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine("RefreshPath");
    }

    private void OnDisable()
    {
        StopCoroutine("RefreshPath");
    }

    IEnumerator RefreshPath()
    {
        Vector2 targetPositionOld = target.position.xy() + Vector2.up;

        while (true)
        {
            if (targetPositionOld != target.position.xy())
            {
                targetPositionOld = target.position;
                path = Pathfinding.RequestPath(transform.position, target.position);
                StopCoroutine("FollowPath");
                StartCoroutine("FollowPath");
            }

            yield return new WaitForSeconds(refreshInterval);
        }
    }

    IEnumerator FollowPath()
    {
        if (path.Length > 0)
        {
            targetIndex = 0;
            Vector2 currentWaypoint = path[0];

            while (true)
            {
                if (transform.position.xy() == currentWaypoint)
                {

                    targetIndex++;
                    if (targetIndex >= path.Length)
                        yield break;
                    currentWaypoint = path[targetIndex];
                }

                //add condition for only if not close enought to player
                /*var direction = Vector2.zero;
                if (Vector2.Distance(transform.position, pc.transform.position) > minimumDistanceToPlayer)
                {
                    direction = currentWaypoint - transform.position.xy();
                    transform.up = direction;
                    rb.velocity = direction.normalized * speed;
                }
                else
                {
                    rb.velocity = Vector2.zero;
                }*/

                if (Vector2.Distance(transform.position, pc.transform.position) > minimumDistanceToPlayer)
                {
                    transform.position = Vector2.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
                }
                rb.velocity = Vector2.zero;
                yield return null;
            }
        }
    }

    public void OnDrawGizmos()
    {
        if (path == null)
            return;

        for (int i = targetIndex; i < path.Length; i++)
        {
            Vector2 lineStart = (i == targetIndex) ? transform.position.xy() : path[i - 1];

            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(path[i], 0.2f);
            Gizmos.DrawLine(lineStart, path[i]);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            aggroed = true;
            target = pc.transform;
        }

        
    }

    private void OnBecameInvisible()
    {
        aggroed = false;
        target = startingPosition.transform;
    }

}
