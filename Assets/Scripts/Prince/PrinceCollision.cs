using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinceCollision : MonoBehaviour
{
    private Prince _p;
    private List<string> _tags;
    private void Awake()
    {
        _p = gameObject.GetComponent<Prince>();
        _tags = new List<string>(new string[] { "Wall", "Player" });
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!_tags.Contains(col.transform.tag)) return;
        var inNormal = col.contacts[0].normal;
        var direction = _p.Direction;
        var prevDir = direction;
        direction = Vector2.Reflect(direction, inNormal);
        _p.Direction = Quaternion.FromToRotation(prevDir, direction) * _p.Direction;
    }
}
