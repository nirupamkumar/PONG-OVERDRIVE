using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastHitPaddleController : MonoBehaviour
{
    
    public GameObject paddle1;
    public GameObject paddle2;

    public GameObject lastHitPaddle;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == paddle1 || col.gameObject == paddle2)
        {
            lastHitPaddle = col.gameObject;
        }
    }


    public GameObject GetOppositePaddle(GameObject currentPaddle)
    {
        if (currentPaddle == paddle1) 
        { 
            return paddle2; 
        }
        else if (currentPaddle == paddle2) 
        {  
            return paddle1; 
        }
        else 
        { 
            return null; 
        }
    }
}
