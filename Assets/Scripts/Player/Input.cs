using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]
public class Input : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Player _p;
    private Vector2 _dir;
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _p = gameObject.GetComponent<Player>();
    }
    private void Update()
    {
        var horizontal = UnityEngine.Input.GetAxis("Horizontal");
        var vertical = UnityEngine.Input.GetAxis("Vertical");
        _dir = new Vector2(horizontal, vertical).normalized;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition((Vector2)transform.position + _dir * (_p.Speed * Time.deltaTime));
    }
}
