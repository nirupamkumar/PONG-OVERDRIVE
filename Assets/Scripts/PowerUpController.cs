using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public float powerupMoveSpeed = 0.0f;
    LastHitPaddleController lastHitPaddleController;

    private void Start()
    {
        lastHitPaddleController = GameObject.FindWithTag("Ball").GetComponent<LastHitPaddleController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GameObject lastHit = lastHitPaddleController.lastHitPaddle;
            GameObject oppositePaddle = lastHitPaddleController.GetOppositePaddle(lastHit);
            PaddleController paddleController = oppositePaddle.GetComponent<PaddleController>();

            if (paddleController != null && !paddleController.HasPowerEffect())
            {
                paddleController.ApplyPowerEffect(powerupMoveSpeed);
            }

            GameManager.instance.SpawnPowerupsAfterDestroyed(false);
            GameManager.instance.DestroyGameObject(gameObject);
        }
    }
}
