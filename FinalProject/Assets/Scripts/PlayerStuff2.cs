using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStuff2 : MonoBehaviour
{
    Vector2 Move;
    Transform player;
    public Animator animator;
    Rigidbody2D playerBody;
    float jump;
    public static int starCollect = 0;
    public static int playerHealth = 5;
    int jumpCount = 1;
    float trapJump = 500;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform;
        animator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = new Vector2(Input.GetAxis("Horizontal") * 3f, 0.0f);
        jump = 300f;
        transform.Translate(Move * Time.deltaTime);
        if (Input.GetAxis("Horizontal") < 0)
        {
            player.localScale = new Vector2(-4f, 4f);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            player.localScale = new Vector2(4f, 4f);
        }
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && playerBody.velocity.y >= 0 && jumpCount > 0)
        {
            playerBody.AddForce(transform.up * jump);
            animator.SetBool("IsJumping", true);
            jumpCount = 0;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("IsJumping", false);
            jumpCount = 1;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            playerHealth = playerHealth - 1;
            if (playerHealth < 1)
            {
                Debug.Log("Game Over");

            }
            else
            {
                Debug.Log("Ouch!");
            }
        }
        if (collision.gameObject.tag == "TrapSpike")
        {
            playerHealth = playerHealth - 2;
            playerBody.AddForce(transform.up * trapJump);
            if (playerHealth < 1)
            {
                Debug.Log("Game Over");
                SceneManager.LoadScene("Lose");
            }
        }
        if (collision.gameObject.tag == "TrapSpikeBall")
        {
            playerHealth = playerHealth - 2;
            if (playerHealth < 1)
            {
                Debug.Log("Game Over");
                SceneManager.LoadScene("Lose");
            }
        }
        if (collision.gameObject.tag == "GameWin")
        {
            SceneManager.LoadScene("WIN");
            playerHealth = 5;
        }
    }
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Star")
        {
            PlayerStuff.starCollect = PlayerStuff.starCollect + 1;
        }
        if (trigger.gameObject.tag == "LevelFinish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            playerHealth = 5;
        }
        if (trigger.gameObject.tag == "LevelDoor1")
        {
            transform.position = new Vector2(13f, 0f);
        }
        if (trigger.gameObject.tag == "LevelDoor2")
        {
            transform.position = new Vector2(32f, 0f);
        }
        if (trigger.gameObject.tag == "LevelDoor3")
        {
            transform.position = new Vector2(56f, 0f);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
