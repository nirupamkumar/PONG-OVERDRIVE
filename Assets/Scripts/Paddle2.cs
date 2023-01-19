using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle2 : MonoBehaviour
{
    public float MoveSpeed = 10.0f;

    [SerializeField]
    private float MoveRange = 5.0f;

    private void Update()
    {
        float input = Input.GetAxis("PlayerRight");

        Vector3 pos = transform.position;
        pos.y += input * MoveSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp( pos.y, -MoveRange, MoveRange);

        transform.position = pos;
    }
}
