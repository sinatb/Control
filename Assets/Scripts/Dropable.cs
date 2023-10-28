using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropable : MonoBehaviour
{
    public float AddTime;
    [SerializeField] private float LifeTime;
    private void Update()
    {
        if (LifeTime <= 0)
            Destroy(gameObject);
        LifeTime -= Time.deltaTime;
    }
}
