using UnityEngine;

public class BasicEnemyFactory : EnemyFactory
{
    [SerializeField] private GameObject enemyprefab;
    public override IEnemy GetEnemy(Vector3 pos)
    {
        GameObject instance = Instantiate(enemyprefab, pos, Quaternion.identity,gameObject.transform);
        IEnemy enemy = instance.GetComponent<BasicEnemy>();
        return enemy;
    }
}
