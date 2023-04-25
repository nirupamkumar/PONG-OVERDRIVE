using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power", menuName = "ScriptableObjects/NewPowerUps")]
public class PowerUps : ScriptableObject
{
    public string powerUpName;
    public GameObject powersPrefab;
    public float moveSpeed;
}
