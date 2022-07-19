using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Vector2 movement;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private PlayerPickup playerPickup;

    [SerializeField]
    private int movementSpeed = 5;



    private void Awake()
    {
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
}
