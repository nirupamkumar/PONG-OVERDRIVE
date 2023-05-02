using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWaveEffectController : MonoBehaviour
{
    ///LastHitPaddleController lastHitPaddleController;
    BallController ballController;

    private void Start()
    {
        //lastHitPaddleController = GameObject.FindWithTag("Ball").GetComponent<LastHitPaddleController>();
        ballController = GameObject.FindWithTag("Ball").GetComponent <BallController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            //GameObject lastHit = lastHitPaddleController.lastHitPaddle;
            //GameObject oppositepaddle = lastHitPaddleController.GetOppositePaddle(lastHit);
            //BallController ballController = oppositepaddle.GetComponent<BallController>();

            if (ballController != null && !ballController.HasSinWavePowerEffect())
            {
                ballController.SinWaveActivate(true);
                Debug.Log("Sin wave active is true");
            }

            GameManager.instance.SpawnPowerupsAfterDestroyed(false);
            GameManager.instance.DestroyGameObject(gameObject);
        }
    }
}
