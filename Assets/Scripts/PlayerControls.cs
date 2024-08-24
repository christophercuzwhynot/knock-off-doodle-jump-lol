using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    [Header("Rigidbody")]
    public Rigidbody2D rb;


    [Header("Default Down Speed")]
    public float downSpeed = 20f;


    [Header("Default Movement speed")]
    public float movementSpeed = 10f;
    

    [Header("default Directional Movement speed")]
    public float movement = 0f;
    //score of game
    [Header("Score Text")]
    public Text scoreText;
    private float topScore = 0.0f;
    
    //Start is called before the first frame update
    void Start()
    {
        //variable equals to component Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //if and players velocity is greater than 0
        /// and position on the y axis is greater 
        //than the score
        if (rb.velocity.y > 0 && transform.position.y > topScore)
        {
            //score equals players position
            topScore = transform.position.y;
        }
        //Text for the score equals the top score
        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
        // movement equals Horizontal movement
        //multiplied by the movement speed
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        //if direction on z axis is less than 0
        if (movement < 0)
        {
            //object faces to the left
            this.GetComponent<SpriteRenderer>().flipX = false;    
        }
        //ifdirection on x is greater than 0
        else
        {
            //objcect faces to the right
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void FixedUpdate()
    {
        //vector2 which is (x,y) velocity
        //equals to the velocity of the rigidbodyy2S
        Vector2 velocity = rb.velocity;
        //velocity of the x axis equals to 
        //the direction movement on the x axis
        //of the character.
        velocity.x = movement;
        //Rigidbody2D velocity equals to //velocity of the object 
        rb.velocity = velocity;
    }
    //collisionFunction 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocity = rb.velocity;
        if (velocity.y <= 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, downSpeed, 0);
        }
    }
}