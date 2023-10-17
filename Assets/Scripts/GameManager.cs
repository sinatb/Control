using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private EnemyFactory[] factories;
    [SerializeField] private float spawntimer;
    private bool canSpawn = true;
    private int _basicEnemyCount;
    private int _advancedEnemyCount;

    public static void BasicEnemyMorph(Vector2 spawnPos)
    {
        //morph logic here
    }
    private IEnumerator SpawnTimer()
    {
        if (!canSpawn)
        {
            yield return new WaitForSeconds(spawntimer);
            canSpawn = true;
        }
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void EnemySpawner()
    {
        if (_basicEnemyCount < 5 && canSpawn)
        {
            var x = Random.Range(-11.0f, 11.0f);
            var y = Random.Range(-4.0f, 4.0f);
            factories[0].GetEnemy(new Vector3(x, y, 1.0f));
            _basicEnemyCount++;
            canSpawn = false;
            StartCoroutine(SpawnTimer());
        }
    }
    private void Update()
    {
        EnemySpawner();
    }
}
