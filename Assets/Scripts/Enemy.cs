using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject nest;
    private GameObject barrier;
    [SerializeField]
    public GameManager gameManager;
    private Rigidbody2D rigid;
    [SerializeField]
    private float moveSpeed;
    private EnemySpawner mySpawner;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        nest = gameManager.nest.gameObject;
        barrier = gameManager.barrier.gameObject;
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (gameManager.barrier.GetComponent<Barrier>().barrierActive)
        {
            MoveToPoint(barrier);
        }
        else
        {
            MoveToPoint(nest);
        }
    }

    private void MoveToPoint(GameObject target)
    {
        Vector2 moveDir = target.transform.position - this.transform.position;
        moveDir.Normalize();
        rigid.MovePosition((Vector2)gameObject.transform.position + (moveDir * moveSpeed * Time.deltaTime));
        //Debug.Log(moveDir * moveSpeed * Time.deltaTime);
    }

    public void setMySpawner(EnemySpawner spawner)
    {
        mySpawner = spawner;
    }

    void removeEnemy()
    {
        mySpawner.enemiesSpawned.Remove(gameObject);
    }

    private void OnDestroy()
    {
        removeEnemy();
    }
}
