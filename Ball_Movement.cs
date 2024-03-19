using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    
    
    //declare speed, this is essentially the initial speed
    public float ballSpeed;

    //we declare a rigidbody variable because we know we're going to manipulate the physics of the ball
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //even though we declared a rigidbody variable earlier, that variable is empty
        //we need to, like all variables, ASSIGN it a value,
        //in this case, we get the rigidbody of the current object - the ball
        rb = GetComponent<Rigidbody2D>();
        gm = GameManager.FindInstance();
        //call the launch function at Start, so it is only done once at the beginning of the game
        Launch();
    }

    private void Launch()
    {
        //randomize x and y values to give the ball a direction
        float x = Random.value < 0.5 ? -1.0f : 1.0f ;
        float y = Random.value < 0.5 ? Random.Range(-1.0f, -.5f) : Random.Range(.5f, 1f);

        //create a direction vector variable using those x and y vals
        Vector2 direction = new Vector2(x, y);

        //add new physics to the ball, direction and speed
        rb.AddForce(direction * ballSpeed);
    }

    //set up collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("player"))
        {
            Debug.Log("hit");
            //ballSpeed = ballSpeed + 10;
            rb.AddForce(rb.velocity * 10);
        }

        if (collision.gameObject.tag.Equals("boundaryL"))
        {
            Debug.Log("Left boundary hit");
            //Player two will score
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("boundaryR"))
        {
            Debug.Log("Right boundary hit");
            //Player one will score
            Destroy(gameObject);
        }
    }
}