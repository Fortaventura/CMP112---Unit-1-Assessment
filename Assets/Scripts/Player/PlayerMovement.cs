
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 0;

    public int JumpForce;
    public float boostSpeed = 120;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
/*
    void OnMovement (InputValue movementValue)
    {
        Vector2 moveVector = moveValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
*/
    
    private void FixedUpdate()
    {
        if (Input.GetKey(Keycode.Space) || Input.GetKey(Keycode.UpArrow))
        {
            rb.AddForce(Vector2.Vertical * JumpForce);
        }







        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2 (speed, rb, velocity.y);

        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2 (speed, rb, velocity.y);

        }
        else
        {
            rb.velocity = 0; //new Vector2 (speed, rb, velocity.y);
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



    // Update is called once per frame
    void Update()
    {
        
    }


*/
}

