//using System.Numerics;
//using System.Numerics;
//using System.Diagnostics;
//using System.Diagnostics;
//using System.Numerics;
//using System.Numerics;
//using System.Diagnostics;
//using System.Numerics;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Some of the following code was drawn from the movement tutorial: https://www.youtube.com/watch?v=2wqgBhnsL28
 
    [SerializeField] private float  speed = 4f;
    private MovementInputActions MovementInputActions;
    private Vector2 movement;
    //Any code involving the above variables was derived from the above video, in addition to the movementInputActions object in the scripts folder


    private Rigidbody2D rb;
    //public int stillness = 0;
    [SerializeField] private float JumpForce = 5f;

    [SerializeField] private LayerMask groundMask;
    public float boostSpeed = 120;

    void Awake()
    {
        MovementInputActions = new MovementInputActions();
        rb = gameObject.GetComponent<Rigidbody2D>();
        MovementInputActions.Moving.Jumping.performed += OnJump;
    }

    private void OnEnable()
    {
        MovementInputActions.Enable();
    }
    /*
    private void OnDisable()
    {
        MovementInputActions.Disable();
    }
    */
    void Update()
    {
        movement = MovementInputActions.Moving.Movement.ReadValue<Vector2>();
       
        
        if (Input.GetButtonDown("Jump")) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
            Debug.Log("I'm Jumping");
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
        rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y) ;
        
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (OnGround())
        {
           rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce); 
        }
        
    }

    private bool OnGround()
    {
        RaycastHit2D RayDetect = Physics2D.Raycast(transform.position,Vector2.down, 0.1f, 1 << 6);

        Debug.DrawRay(transform.position, Vector2.down);

        if (RayDetect.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


/*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boost"))
        {
            //Destroy(gameObject);

            speed = 120;
        }
        else if (collision.gameObject.CompareTag("Spike"))
        {
            //Play the death animation

            //Levelmanager.resetlevel();
            
        }
    }
*/
}



