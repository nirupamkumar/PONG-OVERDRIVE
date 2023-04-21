using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //ball movement
    public float speed = 5.0f;
    private float playAreaWidth = 8.0f;
    //public float playAreaHeight = 5.0f;
    private Vector3 ballDirection;
    private float ballMovementSpeed;

    //storing the paddle information last ball touches
    public GameObject paddle1;
    public GameObject paddle2;
    public GameObject lastHitPaddle;

    private void Start()
    {
        //ballDirection = new Vector3 (1.0f, 0.5f, 0).normalized;
        ballDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized;
        ballMovementSpeed = speed;
    }

    private void Update()
    {
        transform.position += ballDirection * ballMovementSpeed * Time.deltaTime;

        /*
        if (transform.position.y > playAreaHeight || transform.position.y > -playAreaWidth)
        {
            ballDirection.y = -ballDirection.y;
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, ballDirection, out hit, 0.1f))
        {
            if (hit.collider.tag == "P1" || hit.collider.tag == "P2")
            {
                ballDirection.x = -ballDirection.x;
                //ballMovementSpeed += 1.0f;
            }
            else if (hit.collider.tag == "Blocker")
            {
                ballDirection = -ballDirection;
                Destroy(hit.collider.gameObject);
            }
        }
        */

        if (transform.position.x > playAreaWidth)
        {
            ResetBall(-1);
        }
        else if(transform.position.x < -playAreaWidth)
        {
            ResetBall(1);
        }
    }

    IEnumerator ResetBallDelay(float delay, int direction)
    {
        yield return new WaitForSeconds(delay);

        transform.position = Vector3.zero;
        ballDirection = new Vector3(direction, Random.Range(-0.5f, 0.5f), 0f).normalized;
        ballMovementSpeed = speed;
    }

    void ResetBall(int direction)
    {
        StartCoroutine(ResetBallDelay(0.1f, direction));
    }

    private void OnCollisionEnter(Collision col)
    {
        ballDirection = Vector3.Reflect(ballDirection, col.contacts[0].normal);

        if (col.gameObject == paddle1 || col.gameObject == paddle2)
        {
            lastHitPaddle = col.gameObject;
        }
    }


    //Power implmentations here
    //Effect activate and deactivatepower implmentations also here
    //when the ball touches powerup which will spawn in gamemanager effect will activate
    //when the ball collide with anything the power will deactivate

}
