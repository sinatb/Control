using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]
    private float speed;

    [SerializeField] private float damage;
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.transform.CompareTag("player_bullet"))
        {
            var b = col.gameObject.GetComponent<IEnemy>();
            b?.ReceiveDamage(damage);
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        _rb.MovePosition((Vector2)transform.position+ (Vector2)transform.up * (Time.deltaTime*speed));
    }
}
