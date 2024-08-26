using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 5;
    public int lives = 3;

    private bool isOnGround;

    SpriteRenderer playerSprite;
    Rigidbody2D playerRb;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        

    transform.Translate(Vector2.right * horizontal * speed * Time.deltaTime);
        
        if (horizontal >= 0)
        {
            playerSprite.flipX = false;
        }
        else
        {
            playerSprite.flipX= true;
        }

        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround==true)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse) ;
           isOnGround = false ;
           

        }
       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       isOnGround = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            lives -= 1;
            Destroy(collision.gameObject);

            if (lives == 0)
            {
                Destroy(gameObject);
            }
            gameManager.UpdateHealth();
            
        }


    }

}
