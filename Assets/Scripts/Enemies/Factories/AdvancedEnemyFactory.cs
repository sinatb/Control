using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedEnemyFactory : EnemyFactory
{
    [SerializeField] private GameObject enemyPrefab;
    
    public override IEnemy GetEnemy(Vector3 pos)
    {
        var instance = Instantiate(enemyPrefab, pos, Quaternion.identity,gameObject.transform);
        IEnemy enemy = instance.GetComponent<AdvancedEnemy>();
        return enemy;
    }
}
