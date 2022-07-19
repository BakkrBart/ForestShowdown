using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Nest : MonoBehaviour
{

    public TextMeshPro amountText;
    [SerializeField]
    private int amountInNest;
    [SerializeField]
    private int layerNumberFlower;
    [SerializeField]
    private int layerNumberEnemy;

    private PlayerPickup playerPickup;
    private GameManager gameManager;

    private void Start()
    {
        playerPickup = FindObjectOfType<PlayerPickup>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        FlowerCheck(col);
        EnemyCheck(col);
        amountText.text = amountInNest.ToString() + "/10";
    }

    private void FlowerCheck(Collider2D col)
    {
        if (layerNumberFlower == col.gameObject.layer)
        {
            playerPickup.RemoveItem();
            Destroy(col.gameObject);
            amountInNest++;
            if (amountInNest >= 10)
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
