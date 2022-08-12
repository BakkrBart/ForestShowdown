using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Egg : MonoBehaviour
{

    public TextMeshPro amountText;
    private int amountInEgg;
    private int layerNumberFlower;

    [SerializeField]
    private float maxFlowers;

    private PlayerPickup playerPickup;
    private GameManager gameManager;

    private void Start()
    {
        playerPickup = FindObjectOfType<PlayerPickup>();
        gameManager = FindObjectOfType<GameManager>();
        layerNumberFlower = gameManager.layerNumberFlower;

        amountText.text = amountInEgg.ToString() + "/" + maxFlowers;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        FlowerCheck(col);
        amountText.text = amountInEgg.ToString() + "/" + maxFlowers;
    }

    private void FlowerCheck(Collider2D col)
    {
        if (layerNumberFlower == col.gameObject.layer && amountInEgg < maxFlowers)
        {
            playerPickup.RemoveItem(col.gameObject);
            amountInEgg++;
            if (amountInEgg == maxFlowers && !gameManager.youWon)
            {
                gameManager.currEggs++;
            }
        }
    }
}
