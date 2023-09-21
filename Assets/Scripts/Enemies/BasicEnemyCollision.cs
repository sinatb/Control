using UnityEngine;
[RequireComponent(typeof(BasicEnemy))]
public class BasicEnemyCollision : MonoBehaviour
{
    private BasicEnemy _be;

    private void Awake()
    {
        _be = gameObject.GetComponent<BasicEnemy>();
    }

    //on collision enter => if it is player get destroyed
    //if it is enemy => morph
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            _be.Attack(col.gameObject.GetComponent<Player>());
            Destroy(gameObject);
        }else if (col.transform.CompareTag("Wall"))
        {
            var inNormal = col.contacts[0].normal;
            var direction = _be.Direction;
            var prevDir = direction;
            direction = Vector2.Reflect(direction, inNormal);
            _be.Direction = Quaternion.FromToRotation(prevDir,direction)*_be.Direction;
        }else if (col.transform.CompareTag("Enemy"))
        {
            _be.Speed = 0;
        }
    }
}
