using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject flowerPrefab;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private int flowerAmount;
    [SerializeField]
    private float respawnTime = 3;
    private bool respawnStarted;

    public List<GameObject> flowersSpawned = new List<GameObject>();

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
        for (int i = 0; i < flowerAmount; i++)
        {
            InstantiateFlower();
        }
    }

    void InstantiateFlower()
    {
        GameObject newFlower = Instantiate(flowerPrefab, RandomPoint(), Quaternion.identity);
        newFlower.GetComponent<Flower>().setMySpawner(this);
        newFlower.GetComponent<Flower>().inSpawner = true;
        flowersSpawned.Add(newFlower);
    }

    private Vector2 RandomPoint()
    {
        return new Vector2(
            Random.Range(spriteRenderer.bounds.min.x, spriteRenderer.bounds.max.x),
            Random.Range(spriteRenderer.bounds.min.y, spriteRenderer.bounds.max.y));
    }

    private void RespawnCheck()
    {
        if (flowersSpawned.Count < flowerAmount)
        {
            if (!respawnStarted)
            {
                StartCoroutine(newFlower(respawnTime, flowerAmount - flowersSpawned.Count));
                respawnStarted = true;
            }
        }
    }

    IEnumerator newFlower(float waitTime, float amount)
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < amount; i++)
        {
            InstantiateFlower();
        }
        respawnStarted = false;
    }
}
