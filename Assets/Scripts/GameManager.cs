using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private EnemyFactory[] factories;
    [SerializeField] private float spawntimer;
    private bool canSpawn = true;
    [SerializeField]private int _basicEnemyCount;
    [SerializeField]private int _advancedEnemyCount;

    public delegate void Morph(Vector2 spawnPos);
    public static Morph m;

    public void BasicEnemyMorph(Vector2 spawnPos)
    {
        factories[1].GetEnemy(spawnPos);
        _basicEnemyCount -=2;
        _advancedEnemyCount++;
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
            m += BasicEnemyMorph;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void EnemySpawner()
    {
        if (_basicEnemyCount < 5 && _advancedEnemyCount < 3 && canSpawn)
        {
            var x = Random.Range(-11.0f, 11.0f);
            var y = Random.Range(-4.0f, 4.0f);
            factories[0].GetEnemy(new Vector3(x, y, 1.0f));
            _basicEnemyCount++;
            StopAllCoroutines();
            canSpawn = false;
            StartCoroutine(SpawnTimer());
        }
    }

    public void EnemyDeath(EnemyType e)
    {
        if (e == EnemyType.BasicEnemy)
            _basicEnemyCount--;
        else
            _advancedEnemyCount--;
        StopAllCoroutines();
        canSpawn = false;
        StartCoroutine(SpawnTimer());
    }
    private void Update()
    {
        EnemySpawner();
    }
}
