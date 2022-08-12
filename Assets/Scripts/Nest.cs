using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Nest : MonoBehaviour
{

    public TextMeshPro amountText;
    [SerializeField]
    private int maxFlowers;
    private int amountInNest;
    private int layerNumberFlower;
    private int layerNumberEnemy;

    private PlayerPickup playerPickup;
    private GameManager gameManager;

    [SerializeField]
    private bool fullNestWin;

    private void Start()
    {
        playerPickup = FindObjectOfType<PlayerPickup>();
        gameManager = FindObjectOfType<GameManager>();
        layerNumberEnemy = gameManager.layerNumberEnemy;
        layerNumberFlower = gameManager.layerNumberFlower;

        amountText.text = amountInNest.ToString() + "/" + maxFlowers;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        FlowerCheck(col);
        EnemyCheck(col);
        amountText.text = amountInNest.ToString() + "/" + maxFlowers;
    }

    private void FlowerCheck(Collider2D col)
    {
        if (layerNumberFlower == col.gameObject.layer && amountInNest < maxFlowers)
        {
            playerPickup.RemoveItem(col.gameObject);
            amountInNest++;
            if (amountInNest >= maxFlowers && fullNestWin)
            {
                gameManager.youWon = true;
            }
        }
    }

    private void EnemyCheck(Collider2D col)
    {
        if (layerNumberEnemy == col.gameObject.layer)
        {
            if (amountInNest > 0)
            {
                amountInNest--;
                Destroy(col.gameObject);
            }
            else if (amountInNest == 0)
            {
                gameManager.youLose = true;
                Destroy(col.gameObject);
            }
        }
    }
}
