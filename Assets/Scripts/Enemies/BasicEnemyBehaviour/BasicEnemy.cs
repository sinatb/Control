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
    //check around basic enemy and try to get closer to other basic enemies to morph into 
    //advanced enemies.
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
             if (!changed && hit.transform.CompareTag("Enemy"))
            {
                _direction = direction;
                changed = true;
            }
        }
    }

    //move the enemy to the planed direction with rigidbody
    public void Move()
    {
        _rb.MovePosition((Vector2)transform.position + _direction*(Time.deltaTime*speed));
    }

    public void ReceiveDamage(float amount)
    {
        health -= amount;
    }

    //attacks the player when enters the collision
    public void Attack(Player p)
    {
        p.ReceiveDamage(damage);
    }
    //at start the enemy moves in a random direction
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        //give a random direction for the enemy to move at the start
        var rndx = Random.Range(0.0f, 1.0f);
        var rndy = Random.Range(0.0f, 1.0f);
        _direction = new Vector2(rndx, rndy).normalized;
    }
    //plan the next move
    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
        PlanMove();
    }
    //execute physical movement.
    private void FixedUpdate()
    {
        Move();
    }
}
