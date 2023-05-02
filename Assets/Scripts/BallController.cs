using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //ball movement
    public float speed = 5.0f;
    private float playAreaWidth = 8.2f; //public float playAreaHeight = 5.0f;
    private Vector3 ballDirection;
    private float ballMovementSpeed;

    private bool sinWaveActive = false;
    private float sinWaveduration = 2.5f;

    private void Start()
    {
        ballDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized;
        ballMovementSpeed = speed;
    }

    private void Update()
    {

        if (sinWaveActive)
        {
            //Amplitude can be adjusted from 0.3f to 0.5f
            float yPosition = Mathf.Sin(Time.time * Mathf.PI * 2 / sinWaveduration) * 0.3f;
            transform.position += new Vector3(ballDirection.x, yPosition, ballDirection.z) * ballMovementSpeed * Time.deltaTime;

            //Debug.Log("sin wave power activated");
        }
        else
        {
            transform.position += ballDirection * ballMovementSpeed * Time.deltaTime;
        }

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
        else if (transform.position.x < -playAreaWidth)
        {
            ResetBall(1);
        }
    }

    /*
    IEnumerator ResetBallDelay(float delay, int direction)
    {
        transform.position = Vector3.zero;

        yield return new WaitForSecondsRealtime(delay);

        ballDirection = new Vector3(direction, Random.Range(-0.5f, 0.5f), 0f).normalized;
        ballMovementSpeed = speed;
    }

    void ResetBall(int direction)
    {
        StartCoroutine(ResetBallDelay(2.0f, direction));
    }
    */

    void ResetBall(int direction)
    {
        /*
        float newXPosition = direction * playAreaWidth;
        float newYPosition = Random.Range(-0.5f, 0.5f);
        transform.position = new Vector3(newXPosition, newYPosition, 0f);
        ballDirection = new Vector3(-direction, newYPosition, 0f).normalized;
        ballMovementSpeed = speed; */

        transform.position = Vector3.zero;
        ballDirection = new Vector3(direction, Random.Range(-0.5f, 0.5f), 0f).normalized;
        ballMovementSpeed = speed;
    }

    private void OnCollisionEnter(Collision col)
    {
        ballDirection = Vector3.Reflect(ballDirection, col.contacts[0].normal);
    }

    public void SinWaveActivate(bool sineWaveOnOff)
    {
        sinWaveActive = sineWaveOnOff;
        StartCoroutine(ResetSinWave());
    }

    IEnumerator ResetSinWave()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        sinWaveActive = false;
    }

    public bool HasSinWavePowerEffect()
    {
        return sinWaveActive;
    }

}
