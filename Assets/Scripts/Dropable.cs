using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropable : MonoBehaviour
{
    public float AddTime;
    [SerializeField] private float LifeTime;
    public void die()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if (LifeTime <= 0)
            die();
        LifeTime -= Time.deltaTime;
    }
}
