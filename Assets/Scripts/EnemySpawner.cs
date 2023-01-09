using System.Linq;
using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    public AnimationCurve spawnAmount;
    public AnimationCurve spawnDelay;
    public float curveDivider = 100f;
    public float bossRateInSeconds = 10f;
    public float bossInitialDelay = 120f;
    public float bossHealthMultiplier = 1.5f;

    public EnemySpawnRule[] enemies;
    public EnemySpawnRule[] bosses;

    public Transform[] spawnPoints;

    public bool bossesActive;
    public bool spawnerActive;

    public float BossCooldown { get; private set; }
    public bool BossIsAlive { get; private set; }

    public int BossCount { get; private set; } = 0;

    private float _cooldown;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        BossCooldown = bossInitialDelay + bossRateInSeconds;
    }

    private void Update()
    {
        if (Freezer.Instance.Frozen)
        {
            return;
        }

        SpawnRegularEnemies();
        SpawnBosses();
    }

    private void SpawnRegularEnemies()
    {
        _cooldown -= Time.deltaTime;

        if (_cooldown > 0f || !spawnerActive)
        {
            return;
        }

        _cooldown = spawnDelay.Evaluate(TimeManager.Instance.Time / curveDivider);

        var possibleEnemies = enemies.Where(enemy => enemy.minTime <= TimeManager.Instance.Time).ToArray();

        var amount = Mathf.RoundToInt(spawnAmount.Evaluate(TimeManager.Instance.Time / curveDivider));
        for (var i = 0; i < amount; i++)
        {
            var spawner = spawnPoints[Random.Range(0, spawnPoints.Length)];
            var enemy = possibleEnemies[Random.Range(0, possibleEnemies.Length)];

            Instantiate(enemy.enemyPrefab, spawner.position, spawner.rotation);
        }
    }

    private void SpawnBosses()
    {
        if (!bossesActive)
        {
            return;
        }
        
        BossCooldown -= Time.deltaTime;

        if (BossCooldown > 0f || BossIsAlive)
        {
            return;
        }

        
        var spawner = spawnPoints[Random.Range(0, spawnPoints.Length)];
        var boss = bosses[Random.Range(0, bosses.Length)];

        var instance = Instantiate(boss.enemyPrefab, spawner.position, spawner.rotation);
        var health = instance.GetComponent<Health>();
        health.maxHealth = Mathf.RoundToInt(health.maxHealth * Mathf.Pow(bossHealthMultiplier, BossCount)); 
        
        BossIsAlive = true;
        BossCount++;

        AudioManager.Instance.FadeToBoss();
    }

    public void BossWasKilled()
    {
        BossIsAlive = false; // Ggf. ne HashSet für mehrere Bosse
        BossCooldown = bossRateInSeconds;
        
        AudioManager.Instance.FadeToNormal();
    }
}