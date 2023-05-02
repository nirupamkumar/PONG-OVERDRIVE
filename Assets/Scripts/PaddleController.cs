using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float defaultMoveSpeed = 10.0f;
    public float moveRange = 4.0f;
    public string inputAxis;
    public string playerTag;
    private float currentMoveSpeed;
    private float powerupDuration = 2.5f;
    private bool hasPowerup;

    private void Start()
    {
        currentMoveSpeed = defaultMoveSpeed;
    }

    private void Update()
    {
        float input = Input.GetAxis(inputAxis);

        Vector3 pos = transform.position;
        pos.y += input * currentMoveSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, -moveRange, moveRange);

        transform.position = pos;
    }

    public void ApplyPowerEffect(float powerupMoveSpeed)
    {
        currentMoveSpeed = powerupMoveSpeed;
        hasPowerup = true;
        StartCoroutine(ResetPowerEffect());
    }

    private IEnumerator ResetPowerEffect()
    {
        yield return new WaitForSeconds(powerupDuration);
        currentMoveSpeed = defaultMoveSpeed;
        hasPowerup = false;
    }

    public bool HasPowerEffect()
    {
        return hasPowerup;
    }
}
