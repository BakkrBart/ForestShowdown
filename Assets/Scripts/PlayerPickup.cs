using UnityEngine;
using TMPro;

public class PlayerPickup : MonoBehaviour
{
    //Pickup variables
    [SerializeField]
    private int layerNumber;
    //private bool itemPicked;
    private int itemsPicked;
    [SerializeField]
    private int maxItemsPicked;
    public TextMeshProUGUI itemsPickedText;

    //Flip variables
    [HideInInspector]
    public bool flippedDown; 
    [HideInInspector]
    public bool flippedUp;
    [SerializeField]
    private float posXPosition;
    [SerializeField]
    private float negXPosition;

    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("I have collided");
        ItemPickupCheck(col);
    }

    public void RemoveItem()
    {
        //itemPicked = false;
        itemsPicked--;
        pickupUpdate();
    }

    public void flipPosition()
    {
        if (flippedUp)
        {
            gameObject.transform.localPosition = new Vector3(posXPosition, 0, 0);
        }
        if (flippedDown)
        {
            gameObject.transform.localPosition = new Vector3(negXPosition, 0, 0);
        }
    }

    private void ItemPickupCheck(Collider2D col)
    {
        if (layerNumber == col.gameObject.layer /*&& !itemPicked*/ && itemsPicked < maxItemsPicked)
        {
            Debug.Log("with a FLOWER!");
            col.gameObject.transform.position = gameObject.transform.position;
            col.gameObject.transform.parent = gameObject.transform;
            //itemPicked = true;
            itemsPicked++;
            pickupUpdate();
        }
    }

    private void pickupUpdate()
    {
        itemsPickedText.text = itemsPicked + " / " + maxItemsPicked;
    }
}
