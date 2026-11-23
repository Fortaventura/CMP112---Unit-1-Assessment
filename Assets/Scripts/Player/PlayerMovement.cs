//using System.Numerics;
//using System.Diagnostics;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Some of the following code (the 'Movement Input Actions') was drawn from the movement tutorial: https://www.youtube.com/watch?v=2wqgBhnsL28, though the majority was adapted from the vectors lab exercises

    //This creates a class of a new input, that is defined in the scripts folder and enables movement with 'A' and 'D' and jumping with space

    public GameOverScript gameOverScript;
    public LevelManager LevelManager;
    private MovementInputActions MovementInputActions;

    //Defining a 2D vector for movement
    private Vector2 movement;

    //Creating a rigidbody component for the player sprite.
    private Rigidbody2D rb;

    public int stillness = 0; //This was intended to be used for friction to gradually slow down the player. But it's scope creep :/

    //Defining the speed of the player and how high they can jump
    [SerializeField] private float JumpForce = 5f;
    [SerializeField] private float speed = 4f;

    //This creates a new mask for the ground, that is used to prevent in-air jumping using raycasting later on.
    [SerializeField] private LayerMask groundMask;

    //These control how much the dash increases the player's speed, the duration of the dash, whether their position updates, & their most recent direction.
    public float boostSpeed = 1f;
    public float dashTime = 0.01f;
    [HideInInspector] public bool dashing = false;
    [HideInInspector] public float savedDirection = 1; //Positive goes right, negative goes left.

void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    
        //Creates an object so that the new inputs can be referred to.
        MovementInputActions = new MovementInputActions();

        //Defines the rigidbody(2D) component for the player
        rb = gameObject.GetComponent<Rigidbody2D>();    

        //Adds the path of inputs for jumping, so that the inputs are accepted
        MovementInputActions.Moving.Jumping.performed += OnJump;
    }


    //Enabling (and disabling) the custom keybinds for movement and jumping
    private void OnEnable()
    {
        MovementInputActions.Enable();
    }
    private void OnDisable()
    {
        MovementInputActions.Disable();
    }

    void Update()   //Gets the player movement value (left, right or null) from the added input paths, and detects jump inputs
    {
        movement = MovementInputActions.Moving.Movement.ReadValue<Vector2>();
       
        if (Input.GetButtonDown("Jump") && OnGround())
        { //The jump input is ONLY performed if the player is on the ground when the input is detected. This is checked through the OnGround function (Line 97)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
        }
    }

    private void FixedUpdate()
    {
        if (!dashing) //Stops the player's velocity from updating while dashing.
        {
            rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);
            if (movement.x != 0)
            { //Saves whether the player was most recently moving left or right.
                savedDirection = movement.x; //For moving in the correct direction for dashing.
            }
        }
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (OnGround())
        {
            //If the raycaster does detect an object of the ground class, then increase the vertical player velocity by the jumpforce
           rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce); 
        }
    }

    private bool OnGround()
    {
        //This makes a new 2d raycast object at the center of the player, and points it down. The radius (0.6) extends barely beyond the player sprite and only detects objects of layer 6 (all ground tiles are this layer)
        RaycastHit2D RayDetect = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 6);

        Debug.DrawRay(transform.position, Vector2.down);

        //If ground is detected, return true, else false
        if (RayDetect.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Spikes"))
        {
            LevelManager.Died();
        }
        else if (collision.gameObject.CompareTag("Door"))
        {
            LevelManager.Completed();
            //LevelManager.LoadNextLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boost")) //Looking for dash orbs.
        {
            rb.linearVelocity += new Vector2(savedDirection * boostSpeed, rb.linearVelocity.y);
            dashing = true; //Prevents FixedUpdate from updating the player's velocity while dashing.
            StartCoroutine(Wait(dashTime));
        }
    }
    
    private IEnumerator Wait(float secs) //Use of IEnumerator gleaned from: https://discussions.unity.com/t/how-waitforseconds-works-in-c/447105/19
    {
        yield return new WaitForSeconds(secs);
        dashing = false;
    }
}