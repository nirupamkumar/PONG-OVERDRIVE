using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float moveRange = 4.0f;
    public string inputAxis;
    public string playerTag;

    private void Update()
    {
        float input = Input.GetAxis(inputAxis);

        Vector3 pos = transform.position;
        pos.y += input * moveSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, -moveRange, moveRange);

        transform.position = pos;
    }
}
