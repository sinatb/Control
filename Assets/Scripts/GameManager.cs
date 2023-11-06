using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private EnemyFactory[] factories;
    [SerializeField] private float spawntimer;
    private bool canSpawn = true;
    private int _basicEnemyCount;
    private int _advancedEnemyCount;
    [SerializeField] private TextMeshProUGUI timer;
    private float timer_value;
    private bool _isgameRunning = true;

    public delegate void Morph(Vector2 spawnPos);
    public static Morph m;

    public delegate void GameOver();
    public static GameOver gm;

    public delegate void Restart();
    public static Restart rs;
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
            gm += gameover;
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
    private void gameover()
    {
        canSpawn = false;
        _isgameRunning = false;
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
    private void UpdateTimer() 
    {
        timer.text = timer_value.ToString("0.00");
    }
    private void Update()
    {
        EnemySpawner();
        if (_isgameRunning)
        {
            timer_value += Time.deltaTime;
            UpdateTimer();
        }
    }
}
