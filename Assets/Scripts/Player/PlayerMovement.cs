//using System.Numerics;
//using System.Numerics;
//using System.Diagnostics;
//using System.Diagnostics;
//using System.Numerics;
//using System.Numerics;
//using System.Diagnostics;
//using System.Numerics;
using System.Xml.Serialization;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Some of the following code (the 'Movement Input Actions') was drawn from the movement tutorial: https://www.youtube.com/watch?v=2wqgBhnsL28, though the majority was adapted from the vectors lab exercises

    //This creates a class of a new input, that is defined in the scripts folder and enables movement with 'A' and 'D' and jumping with space
    private MovementInputActions MovementInputActions;

    //Defining a 2D vector for movement
    private Vector2 movement;
    

    //creating a rigidbody component for the player sprite
    private Rigidbody2D rb;

    public int stillness = 0; //This was intended to be used for friction to gradually slow down the player. But it's scope creep :/

    //Defining the speed of the player and how high they can jump
    [SerializeField] private float JumpForce = 5f;
    [SerializeField] private float speed = 4f;

    //This creates a new mask for the ground, that is used to prevent in-air jumping using raycasting later on.
    [SerializeField] private LayerMask groundMask;

    //These control how much the dash multiplies the player's speed, and their most recent direction (Positive for right, negative for left).
    public float boostSpeed = 120f;
    public float savedDirection = 1;

    void Awake()
    {
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
        {
            //The jump input is ONLY performed if the player is on the ground when the input is detected. This is checked through the OnGround function (Line 105)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
            
        }

/*
        if (Input.GetButtonDown("Left"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.y, speed);
        }
        else if (Input.GetButtonDown("Right"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.y,-speed);
        }
        else
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.y, stillness);
        }*/
        
    }

    
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);
        if (movement.x != 0)
        { //Saves whether the player was most recently koving left or right so that the dash powerups send them in the correct direction.
            savedDirection = movement.x; 
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
        RaycastHit2D RayDetect = Physics2D.Raycast(transform.position,Vector2.down, 0.6f, 1 << 6);

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



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Spikes"))
        {
            //Destroy(this.gameObject);

            //levelManager.resetlevel;
        }
        else if (collision.gameObject.CompareTag("Spikes"))
        {
            //Play the death animation

            //Levelmanager.resetlevel();

        }
        else if (collision.gameObject.CompareTag("Boost"))
        {
            Debug.Log("Boosted");
            rb.linearVelocity = new Vector2(savedDirection * boostSpeed, rb.linearVelocity.y);
        }
    }
}



