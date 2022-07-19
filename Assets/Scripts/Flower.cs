using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private FlowerSpawner mySpawner;

    //[HideInInspector]
    public bool inSpawner;

    public void setMySpawner(FlowerSpawner spawner)
    {
        mySpawner = spawner;
    }

    [ContextMenu("removeFlower")]
    void removeFlower()
    {
        if (inSpawner)
        {
            mySpawner.flowersSpawned.Remove(gameObject);
            inSpawner = false;
        }
    }

    private void OnDestroy()
    {
        removeFlower();
    }
}
