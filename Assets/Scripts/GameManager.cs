using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject nest;
    public GameObject barrier;
    [HideInInspector]
    public bool youWon;
    [HideInInspector]
    public bool youLose;

    [SerializeField]
    private int eggsToWin;
    [HideInInspector]
    public int currEggs;

    public int layerNumberFlower;
    public int layerNumberEnemy;

    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private GameObject loseScreen;
    [SerializeField]
    private PlayerControls player;

    private Scene currScene;

    private void Start()
    {
        currScene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        if (currEggs >= eggsToWin)
        {
            youWon = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Slay");
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(currScene.name);
        }
        if (youWon && !youLose)
        {
            winScreen.SetActive(true);
            player.enabled = false;
        }
        if (youLose && !youWon)
        {
            loseScreen.SetActive(true);
            player.enabled = false;
        }
    }
}
