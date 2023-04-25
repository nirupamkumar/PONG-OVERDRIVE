using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            GameManager.instance.DestroyGameObject(gameObject);
            GameManager.instance.SpawnBlockerAfterItDestroyed(false);
        }
    }
}
