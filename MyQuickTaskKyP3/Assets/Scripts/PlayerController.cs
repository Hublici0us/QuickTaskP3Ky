using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 5;

    SpriteRenderer playerSprite;
    Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();
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
            playerSprite.flipX = true;
        }
        else
        {
            playerSprite.flipX= false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse) ;
        }
    }
}
