using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerMovementScript : MonoBehaviour
{
    // Movement 
    public Vector3 upDirection;
    public Vector3 downDirection;
    public Vector3 leftDirection;
    public Vector3 rightDirection;
    // Code for the bullet not to move the Player
    public Vector3 leftBulletOffset;
    public Vector3 rightBulletOffset;

    // Bullets 
    public GameObject leftBulletPrefab;
    public GameObject rightBulletPrefab;

    //reference for the GameManager
    public GMScript gameManagerObject;

    //  Timer for unfreezing the player
    public float freezeTimer;

    // If the player won
    public bool playerWon;
    // Freezing the player
    public bool playerFreeze; 

    // Where the player is facing
    public int playerFacing;

    // Win or lose text
    public TextMeshProUGUI WinOrLose;

    // Start is called before the first frame update
    void Start()
    {
        playerWon = false;
        // Find the GameManager
        gameManagerObject = GameObject.Find("GameManager").GetComponent<GMScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // If statement for unfreezing the player
        if (playerFreeze == true)
        {
            freezeTimer += Time.deltaTime;
            if (freezeTimer >= 10f)
            {
                playerFreeze = false;
                freezeTimer = 0;
                WinOrLose.text = "  ";
            }
        }

        //Movement code
        if (Input.GetKey(KeyCode.W)) // When W pressed go up
        {
            if (playerFreeze == false)
            {
                GetComponent<Transform>().position += upDirection;
                GetComponent<Animator>().Play("UpWalk");
            }
            
        }

        else if (Input.GetKey(KeyCode.S)) // When S pressed go down
        {
            if (playerFreeze == false)
            {
                GetComponent<Transform>().position += downDirection;
                GetComponent<Animator>().Play("DownWalk");
            }
                
        }

        else if (Input.GetKey(KeyCode.A)) // When A pressed go left
        {
            if (playerFreeze == false)
            {
                GetComponent<Transform>().position += leftDirection;
                GetComponent<Animator>().Play("LeftWalk");
                playerFacing = -1;
            }

        }

        else if (Input.GetKey(KeyCode.D)) // When D pressed go right
        {
            if (playerFreeze == false)
            {
                GetComponent<Transform>().position += rightDirection;
                GetComponent<Animator>().Play("RightWalk");
                playerFacing = 1;
            }

        }
        else
        {
            GetComponent<Animator>().Play("PlayerIdle");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerFacing == 1) // right direction
            {
                 Instantiate(rightBulletPrefab, GetComponent<Transform>().position + rightBulletOffset, Quaternion.identity);
            }

            if (playerFacing == -1) // left direction
            {
                Instantiate(leftBulletPrefab, GetComponent<Transform>().position + leftBulletOffset, Quaternion.identity);
            }

        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // When the player touches the cage it destroys 
        if (collision.gameObject.tag == "Cage")
        {
            Destroy(collision.gameObject);
        }

        //  When the player touches the Bunny they win
        if (collision.gameObject.tag == "Bunny")
        {
            if (playerWon == false && gameManagerObject.Gems >= 3)
            {
                playerWon = true;
                Debug.Log("You win!");
                WinOrLose.text = "You Win!";
                
            }

        }

        //When the player touhes a gem they gain a gem and it disappears
        if (collision.gameObject.tag == "Gem")
        {
            Destroy(collision.gameObject);
            gameManagerObject.Gems += 1;
        }

        //When player touches an enemy the player freezes
        if (collision.gameObject.tag == "Enemy")
        {
            playerFreeze = true;
            Debug.Log("Uh Oh you're frozen! Wait 10 seconds.");
            WinOrLose.text = "Uh Oh you're frozen! Wait 10 seconds.";
        }

    }

}

