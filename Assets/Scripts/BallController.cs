using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //ball movement
    public float speed = 5.0f;
    private float playAreaWidth = 8.2f;
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
        }
        else
        {
            transform.position += ballDirection * ballMovementSpeed * Time.deltaTime;
        }

        if (transform.position.x > playAreaWidth)
        {
            ResetBall(-1);
        }
        else if (transform.position.x < -playAreaWidth)
        {
            ResetBall(1);
        }
    }

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
