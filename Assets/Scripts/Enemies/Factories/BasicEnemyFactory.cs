using UnityEngine;

public class BasicEnemyFactory : EnemyFactory
{
    [SerializeField] private GameObject enemyPrefab;
    public override IEnemy GetEnemy(Vector3 pos)
    {
        var instance = Instantiate(enemyPrefab, pos, Quaternion.identity,gameObject.transform);
        IEnemy enemy = instance.GetComponent<BasicEnemy>();
        return enemy;
    }
}
