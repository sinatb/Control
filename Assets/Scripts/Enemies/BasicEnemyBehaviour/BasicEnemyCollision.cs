using Unity.VisualScripting;
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
            GameManager.Instance.EnemyDeath(EnemyType.BasicEnemy);
            Destroy(gameObject);
            return;
        }
        if (col.transform.CompareTag("Wall") || col.transform.CompareTag("Morphing_Enemy") 
                                             || col.transform.CompareTag("Advanced_Enemy")
                                             || col.transform.CompareTag("Dropable")
                                             || col.transform.CompareTag("Prince"))
        {
            var inNormal = col.contacts[0].normal;
            var direction = _be.Direction;
            var prevDir = direction;
            direction = Vector2.Reflect(direction, inNormal);
            _be.Direction = Quaternion.FromToRotation(prevDir,direction)*_be.Direction;
            return;
        } 
        if (!col.transform.CompareTag("Enemy") || !transform.CompareTag("Enemy")) return;
        var be2 = col.gameObject.GetComponent<BasicEnemy>();
        //changing tag of both enemies
        _be.transform.tag = "Morphing_Enemy";
        be2.transform.tag = "Morphing_Enemy";
        //changing health of both enemies
        _be.Health += be2.Health;
        be2.Health = _be.Health;
        //changing speed of both enemies
        _be.Speed = 0;
        be2.Speed = 0;
        //animate the 2 balls
        _be.GetComponent<BasicEnemyAnimation>().Animate();
        be2.GetComponent<BasicEnemyAnimation>().Animate();
        //
        var bemm = _be.AddComponent<BasicEnemyMorphManager>();
        bemm.SetBes(_be,be2);
    }
}
