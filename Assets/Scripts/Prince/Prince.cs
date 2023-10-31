using UnityEngine;

public class Prince : MonoBehaviour,INCUnit
{
    [SerializeField] private float speed;
    [SerializeField] private float health;
    private Vector2 _direction;
    private Rigidbody2D _rb;
    public float Speed { get => speed; set => speed = value; }
    public float Health { get => health; set => health = value; }
    public Vector2 Direction { get => _direction; set => _direction = value; }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void Move()
    {
        _rb.MovePosition((Vector2)transform.position + _direction * (Time.deltaTime * speed));
    }

    public void PlanMove()
    {
        if (_direction == Vector2.zero)
        {
            var rndx = Random.Range(0.0f, 1.0f);
            var rndy = Random.Range(0.0f, 1.0f);
            _direction = new Vector2(rndx, rndy).normalized;
        }
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
