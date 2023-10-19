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
        if (col.transform.CompareTag("player_bullet") || col.transform.CompareTag("Enemy_Bullet")) return;
        var b = col.gameObject.GetComponent<IEnemy>();
        var c = col.gameObject.GetComponent<Player>();
        if (transform.CompareTag("player_bullet"))
            b?.ReceiveDamage(damage);
        else
            c?.ReceiveDamage(damage);
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        _rb.MovePosition((Vector2)transform.position+ (Vector2)transform.up * (Time.deltaTime*speed));
    }
}
