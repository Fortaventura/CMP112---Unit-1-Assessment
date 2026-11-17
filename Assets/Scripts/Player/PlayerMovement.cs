//using System.Numerics;
//using System.Numerics;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //The following code was drawn from the movement tutorial: https://www.youtube.com/watch?v=2wqgBhnsL28
 
    [SerializeField] private float  speed = 4f;
    private MovementInputActions MovementInputActions;
    private Vector2 movement;

    private Rigidbody2D rb;
    public int stillness = 0;
    public int JumpForce;
    public float boostSpeed = 120;

    void Awake()
    {
        MovementInputActions = new MovementInputActions();
        rb = gameObject.GetComponent<Rigidbody2D>();
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
       
        /*
        if (Input.GetButtonDown("Leap")) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
        }


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
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime) ;
        Debug.Log(movement.x);
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



    // Update is called once per frame
    void Update()
    {
        
    }


*/
}



