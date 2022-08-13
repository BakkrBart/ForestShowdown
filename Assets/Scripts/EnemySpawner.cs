using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    private SpriteRenderer spriteRenderer;

    //parameters
    [SerializeField]
    private int enemyAmount;
    [SerializeField]
    private float respawnTime = 3;
    [SerializeField]
    private float startSpawnTime;
    private bool respawnStarted;

    [HideInInspector]
    public List<GameObject> enemiesSpawned = new List<GameObject>();

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(0, 0, 0, 0);
        StartCoroutine(spawnWave(startSpawnTime, enemyAmount));
    }

    private void Update()
    {
        RespawnCheck();
    }

    void InstantiateEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, RandomPoint(), Quaternion.identity);
        newEnemy.GetComponent<Enemy>().setMySpawner(this);
        enemiesSpawned.Add(newEnemy);
    }

    private Vector2 RandomPoint()
    {
        return new Vector2(
            Random.Range(spriteRenderer.bounds.min.x, spriteRenderer.bounds.max.x),
            Random.Range(spriteRenderer.bounds.min.y, spriteRenderer.bounds.max.y));
    }

    private void RespawnCheck()
    {
        if (enemiesSpawned.Count <= 0)
        {
            if (!respawnStarted)
            {
                StartCoroutine(spawnWave(respawnTime, enemyAmount));
                respawnStarted = true;
            }
        }
    }
    IEnumerator spawnWave(float waitTime, float amount)
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < amount; i++)
        {
            InstantiateEnemy();
        }
        respawnStarted = false;
    }
}
