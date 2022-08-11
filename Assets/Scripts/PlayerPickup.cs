using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PlayerPickup : MonoBehaviour
{
    //Pickup variables
    [SerializeField]
    private int layerNumber;
    //private bool itemPicked;
    [HideInInspector]
    public int itemsPicked;
    [SerializeField]
    private int maxItemsPicked;
    public TextMeshProUGUI itemsPickedText;
    public List<GameObject> pickedObjects;

    //Flip variables
    [HideInInspector]
    public bool flippedDown; 
    [HideInInspector]
    public bool flippedUp;
    [SerializeField]
    private float posXPosition;
    [SerializeField]
    private float negXPosition;

    private void Awake()
    {
        pickedObjects.Capacity = 5;
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("I have collided");
        ItemPickupCheck(col);
    }

    public void RemoveItem()
    {
        //itemPicked = false;
        GameObject deleted = pickedObjects[0];
        pickedObjects.Remove(deleted);
        Destroy(deleted);
        itemsPicked--;
        pickupUpdate();
    }

    public void RemoveItem(GameObject item)
    {
        pickedObjects.Remove(item);
        Destroy(item);
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
            GameObject flower = col.gameObject;
            //itemPicked = true;
            itemsPicked++;
            pickupUpdate();
            Debug.Log(col.gameObject.name);
            pickedObjects.Add(flower);
        }
    }

    private void pickupUpdate()
    {
        itemsPickedText.text = itemsPicked + " / " + maxItemsPicked;
    }
}
