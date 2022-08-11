using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Barrier : MonoBehaviour
{
    public bool barrierActive;

    public TextMeshPro amountText;
    [SerializeField]
    private int amountInBarrier;
    [SerializeField]
    private int layerNumberFlower;
    [SerializeField]
    private int layerNumberEnemy;
    private SpriteRenderer spriteRenderer;

    private PlayerPickup playerPickup;

    [SerializeField]
    private GameObject minimapDot;

    private void Start()
    {
        playerPickup = FindObjectOfType<PlayerPickup>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        BarrierCheck();
    }

    private void Update()
    {
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        FlowerCheck(col);
        EnemyCheck(col);
    }

    private void FlowerCheck(Collider2D col)
    {
        if (layerNumberFlower == col.gameObject.layer)
        {
            playerPickup.RemoveItem(col.gameObject);
            amountInBarrier++;
            BarrierCheck();
        }
    }

    private void EnemyCheck(Collider2D col)
    {
        if (layerNumberEnemy == col.gameObject.layer)
        {
            if (amountInBarrier > 0)
            {
                amountInBarrier--;
                BarrierCheck();
                Destroy(col.gameObject);
            }
        }
    }

    private void BarrierCheck()
    {
        amountText.text = amountInBarrier.ToString();
        if (amountInBarrier > 0)
        {
            barrierActive = true;
            spriteRenderer.color = new Color(1, 1, 1, 1);
            minimapDot.SetActive(true);

        }
        else if (amountInBarrier == 0)
        {
            barrierActive = false;
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            minimapDot.SetActive(false);
        }
    }
}
