using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStuff : MonoBehaviour
{
    Vector2 Move;
    Transform player;
    public Animator animator;
    Rigidbody2D playerBody;
    float jump;
    public static int starCollect = 0;
    public static int playerHealth = 5;
    int jumpCount = 1;
    float trapJump = 300;
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
        Move = new Vector2(Input.GetAxis("Horizontal") * 1f, 0.0f);
        jump = 200f;
        transform.Translate(Move * Time.deltaTime);
        if (Input.GetAxis("Horizontal") < 0)
        {
            player.localScale = new Vector2(-1f, 1f);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            player.localScale = new Vector2(1f, 1f);
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
                SceneManager.LoadScene("Lose");

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
        if (collision.gameObject.tag == "LevelFinish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            playerHealth = 5;
        }
    }
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Star")
        {
            starCollect = starCollect + 1;
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
        playerHealth = 0;
    }
}
