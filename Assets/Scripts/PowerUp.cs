using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject slowEffectObj;
    public GameObject fastEffectObj;
    public GameObject magnetEffectObj;
    public GameObject sinusoidEffectObj;

    public List<GameObject> powerUps;

    private void Update()
    {
        
    }

    private void SlowEffect()
    {
        Debug.Log("SlowEffect PowerUp picked");
    }

    private void OverSpeed()
    {
        Debug.Log("OverSpeed PowerUp picked");
    }

    private void SinsoidMovement()
    {

    }

    private void MagnetEffect()
    {

    }
}
