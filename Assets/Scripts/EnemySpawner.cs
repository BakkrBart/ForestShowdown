using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private int enemyAmount;
    [SerializeField]
    private float respawnTime = 3;
    private bool respawnStarted;

    public List<GameObject> enemiesSpawned = new List<GameObject>();

    private void Start()
    {
        respawnStarted = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(0, 0, 0, 0);
        startGeneration();
    }

    private void Update()
    {
        RespawnCheck();
    }

    void startGeneration()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            InstantiateEnemy();
        }
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
        if (enemiesSpawned.Count < enemyAmount)
        {
            if (!respawnStarted)
            {
                StartCoroutine(newEnemy(respawnTime, enemyAmount - enemiesSpawned.Count));
                respawnStarted = true;
            }
        }
    }

    IEnumerator newEnemy(float waitTime, float amount)
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < amount; i++)
        {
            InstantiateEnemy();
        }
        respawnStarted = false;
    }
}
