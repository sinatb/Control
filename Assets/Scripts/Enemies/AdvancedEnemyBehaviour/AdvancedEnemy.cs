using System;
using System.Collections;
using System.Net;
using UnityEngine;
using Random = UnityEngine.Random;
public class AdvancedEnemy : MonoBehaviour,INCUnit,IEnemy
{
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float attackTime;
    private Player _target;
    private bool _canAttack;
    private float _maxSpeed;
    private Rigidbody2D _rb;
    private Vector2 _direction;
    private bool _isAttacking;
    private AdvancedEnemyShoot _aes;
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

    private IEnumerator AttackTimer(float time)
    {
        _isAttacking = true;
        yield return new WaitForSeconds(time);
        _canAttack = true;
        _isAttacking = false;
    }
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _aes = GetComponent<AdvancedEnemyShoot>();
        _maxSpeed = speed;
        var rndx = Random.Range(0.0f, 1.0f);
        var rndy = Random.Range(0.0f, 1.0f);
        _direction = new Vector2(rndx, rndy).normalized;
    }

    public void PlanMove()
    {
        for (var i = 0; i < 360; i++)
        {
            var q = Quaternion.AngleAxis(i, Vector3.forward);
            var direction = Vector3.up;
            direction = q * direction;
            var hit = Physics2D.Raycast(transform.position, direction,range);
            if (!hit)
            {
                _canAttack = false;
                continue;
            };
            if (!hit.transform.CompareTag("Player")) continue;
            _target = hit.transform.GetComponent<Player>();
            speed = Mathf.Lerp(speed, hit.distance > 3.0f ? _maxSpeed : 0.0f, 0.1f*Time.deltaTime);
            if (hit.distance <= 4.0f && !_isAttacking)
            {
                StartCoroutine(AttackTimer(attackTime));
                _canAttack = false;
            }
            _direction = direction;
        }
    }

    public void Move()
    {
        _rb.MovePosition((Vector2)transform.position + _direction*(Time.deltaTime*speed));
    }

    public void Attack(Player p)
    {
        if (_canAttack)
        {
            _aes.Shoot(p.transform.position);
        }
    }
    public void ReceiveDamage(float amount)
    {
        health -= amount;
    }
    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
        if (_target != null)
            Attack(_target);
        PlanMove();

    }
    private void FixedUpdate()
    {
        Move();
    }
}
