using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BasicEnemy : MonoBehaviour,INCUnit,IEnemy
{
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    private Rigidbody2D _rb;
    private Vector2 _direction;
    private CircleCollider2D _col;
    public float Health
    {
        get => health;
        set => health = value;
    }
    public float Speed
    {
        get => speed;
        set => speed = value;
    }
    public Vector2 Direction => _direction; 
    public float Damage
    {
        get => damage;
        set => damage = value;
    }
    
    
    public void PlanMove()
    {
        bool changed = false;
        for (int i = 0; i < 360; i++)
        {
            Quaternion q = Quaternion.AngleAxis(i, Vector3.forward);
            var direction = Vector3.up;
            direction = q * direction;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction,range);
            if (!hit) continue;
            if (!changed && hit.transform.CompareTag("Player"))
            {
                _direction = direction;
                changed = true;
            }
            else if (!changed && hit.transform.CompareTag("Enemy"))
            {
                _direction = direction;
                changed = true;
            }
        }
    }

    public void Move()
    {
        _rb.MovePosition((Vector2)transform.position + _direction*(Time.deltaTime*speed));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            Attack(col.gameObject.GetComponent<Player>());
            Destroy(gameObject);
        }
    }
    public void Attack(Player p)
    {
        p.ReceiveDamage(damage);
    }
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _col = gameObject.GetComponent<CircleCollider2D>();
        var rndx = Random.Range(0.0f, 1.0f);
        var rndy = Random.Range(0.0f, 1.0f);
        _direction = new Vector2(rndx, rndy).normalized;
    }

    private void Update()
    {
        PlanMove();
    }

    private void FixedUpdate()
    {
        Move();
    }
}
