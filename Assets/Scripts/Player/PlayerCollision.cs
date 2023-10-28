using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Player _p;
    private void Awake()
    {
        _p = GetComponent<Player>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Dropable"))
        {
            var d = collision.gameObject.GetComponent<Dropable>();
            _p.Consume(d);
            d.die();
        }
    }
}
