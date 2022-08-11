using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Vector2 movement;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private PlayerPickup playerPickup;

    private int movementSpeed;
    [SerializeField]
    private int normalSpeed;
    [SerializeField]
    private int highSpeed;



    private void Awake()
    {
        movementSpeed = normalSpeed;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerPickup = GetComponentInChildren<PlayerPickup>();
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + (movement * movementSpeed * Time.deltaTime));
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && !countdownRunning && playerPickup.itemsPicked > 0)
            {
                playerPickup.RemoveItem();
                StartCoroutine(StartSprint());
            }

        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (movement != new Vector2(0, 0))
        {
            animator.SetBool("flying", true);
        }
        else
        {
            animator.SetBool("flying", false);
        }
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;

            playerPickup.flippedDown = true;
            playerPickup.flippedUp = false;
            playerPickup?.flipPosition();
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false;

            playerPickup.flippedUp = true;
            playerPickup.flippedDown = false;
            playerPickup?.flipPosition();
        }
    }

    private float currCountdownValue;
    private bool countdownRunning;

    public IEnumerator StartSprint(float countdownValue = 4)
    {
        countdownRunning = true;
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            if (currCountdownValue > 2)
            {
                movementSpeed = highSpeed;
            }
            else
            {
                movementSpeed = normalSpeed;
            }
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        if (currCountdownValue == 0)
        {
            countdownRunning = false;
        }
    }

}
