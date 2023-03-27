using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float StartSpeed = 5.0f;
    public float MaxSpeed = 20.0f;
    public float SpeedIncrease = 0.25f;

    private float currentSpeed;
    private Vector2 currentDir;
    private bool resetting = false;

    //paddles
    public GameObject paddle1;
    public GameObject paddle2;
    public GameObject lastHitPaddle;

    private void Start()
    {
        currentSpeed = StartSpeed;
        currentDir = Random.insideUnitCircle.normalized;
    }

    private void Update()
    {
        if( resetting) { return; }

        Vector2 moveDir = currentDir * currentSpeed * Time.deltaTime;
        transform.Translate(new Vector3 (moveDir.x, moveDir.y, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.tag == "Boundary")
        {
            currentDir.y *= -1;
        }
        else if( other.tag == "Player")
        {
            currentDir.x *= -1;
        }
        else if( other.tag == "Goal")
        {
            StartCoroutine(resetBall());
            currentDir.x *= -1;
        }

        currentSpeed += SpeedIncrease;
        currentSpeed = Mathf.Clamp( currentSpeed, StartSpeed, MaxSpeed);

        IEnumerator resetBall()
        {
            resetting = true;
            transform.position = Vector3.zero;

            currentDir = Vector3.zero;
            currentSpeed = 0f;

            yield return new WaitForSeconds(3f);

            Start();
            resetting = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject == paddle1 || collision.gameObject == paddle2 )
        {

        }
    }


}
