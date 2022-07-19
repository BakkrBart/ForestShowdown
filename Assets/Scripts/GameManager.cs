using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject nest;
    public GameObject barrier;
    public bool youWon;
    public bool youLose;

    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private GameObject loseScreen;
    [SerializeField]
    private PlayerControls player;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Slay");
        }
        if (youWon)
        {
            winScreen.SetActive(true);
            player.enabled = false;
        }
        if (youLose)
        {
            loseScreen.SetActive(true);
            player.enabled = false;
        }
    }
}
