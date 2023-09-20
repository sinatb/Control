using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject enemyprefab;
    public IEnemy GetEnemy(Vector3 pos)
    {
        GameObject instance = Instantiate(enemyprefab, pos, Quaternion.identity,gameObject.transform);
        IEnemy enemy = instance.GetComponent<BasicEnemy>();
        return enemy;
    }
}
