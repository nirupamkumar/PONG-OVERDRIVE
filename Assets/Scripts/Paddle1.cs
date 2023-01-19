using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Paddle1 : MonoBehaviour
{
    public float MoveSpeed = 10f;

    [SerializeField] 
    private float MoveRange = 5f;

    private void Update()
    {
        float input = Input.GetAxis("PlayerLeft");

        Vector3 pos = transform.position;
        pos.y += input * MoveSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp( pos.y, -MoveRange, MoveRange );

        transform.position = pos;
    }
}
