using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb;

    public float xInitialForce;
    public float yInitialForce;
    public float maxSpeed = 10f;

    private Vector2 trajectoryOrigin;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RestartGame();
        trajectoryOrigin = transform.position;
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity.magnitude != maxSpeed ? rb.velocity.normalized * maxSpeed : rb.velocity;
    }

    void ResetBall()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
    }
    
    void PushBall()
    {
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        float randomDirection = Random.Range(0, 2);

        if(randomDirection < 1.0f)
        {
            rb.AddForce(new Vector2(-xInitialForce, yRandomInitialForce).normalized * 50f);
        }
        else
        {
            rb.AddForce(new Vector2(xInitialForce, yRandomInitialForce).normalized * 50f);
        }
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("PushBall", 2f);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
