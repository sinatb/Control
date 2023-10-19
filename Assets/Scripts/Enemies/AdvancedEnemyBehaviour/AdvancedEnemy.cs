using System;
using UnityEngine;
using Random = UnityEngine.Random;
public class AdvancedEnemy : MonoBehaviour,INCUnit,IEnemy
{
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    private float _maxSpeed;
    private Rigidbody2D _rb;
    private Vector2 _direction;
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

    public Vector2 Direction
    {
        get => _direction;
        set => _direction = value;
    }
    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _maxSpeed = speed;
        //give a random direction for the enemy to move at the start
        var rndx = Random.Range(0.0f, 1.0f);
        var rndy = Random.Range(0.0f, 1.0f);
        _direction = new Vector2(rndx, rndy).normalized;
    }

    public void PlanMove()
    {
        for (int i = 0; i < 360; i++)
        {
            Quaternion q = Quaternion.AngleAxis(i, Vector3.forward);
            var direction = Vector3.up;
            direction = q * direction;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction,range);
            if (!hit) continue;
            if (hit.transform.CompareTag("Player"))
            {
                if (hit.distance > 3.0f)
                    speed = Mathf.Lerp(speed,_maxSpeed,0.1f*Time.deltaTime);
                else
                    speed = Mathf.Lerp(speed, 0.0f, 0.1f*Time.deltaTime);
                _direction = direction;

            }
        }
    }

    public void Move()
    {
        _rb.MovePosition((Vector2)transform.position + _direction*(Time.deltaTime*speed));
    }

    public void Attack(Player p)
    {
        throw new System.NotImplementedException();
    }
    public void ReceiveDamage(float amount)
    {
        health -= amount;
    }
    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
        PlanMove();
    }
    private void FixedUpdate()
    {
        Move();
    }
}
