using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
    public Material material;
    private Color defaultColor;

    void Start()
    {
        defaultColor = material.color;
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        material.color = randomColor;
    }

    private void OnDestroy()
    {
        material.color = defaultColor;
    }
}
