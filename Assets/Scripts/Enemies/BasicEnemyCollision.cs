using UnityEngine;
[RequireComponent(typeof(BasicEnemy))]
public class BasicEnemyCollision : MonoBehaviour
{
    private BasicEnemy _be;

    public delegate void AnimationStart();
    public static event AnimationStart OnAnimationStart;
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
            var be2 = col.gameObject.GetComponent<BasicEnemy>();
            //changing tag of both enemies
            _be.gameObject.tag = "Morphing_Enemy";
            be2.gameObject.tag = "Morphing_Enemy";
            //changing health of both enemies
            var tmp = _be.Health;
            _be.Health += be2.Health;
            be2.Health += tmp;
            //changing speed of both enemies
            _be.Speed = 0;
            be2.Speed = 0;
            OnAnimationStart?.Invoke();
        }
    }
}
