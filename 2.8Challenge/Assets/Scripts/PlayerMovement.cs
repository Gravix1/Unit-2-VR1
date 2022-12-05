using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Vector2 Move;
    Transform player;
    public Animator animator;
    Rigidbody2D playerBody;
    float jump;
    public static int acornCollect = 0;
    public static int playerHealth = 5;
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
        Move = new Vector2(Input.GetAxis("Horizontal") * 3, 0.0f);
        jump = 250f;
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
        if (Input.GetKeyDown(KeyCode.UpArrow) && playerBody.velocity.y >= 0)
        {
            playerBody.AddForce(transform.up * jump);
            animator.SetBool("IsJumping", true);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("IsJumping", false);
        }
        if (collision.gameObject.tag == "Acorn")
        {
            Debug.Log("NOM NOM NOM");
            animator.SetBool("IsJumping", false);
            acornCollect = acornCollect + 1;
            Debug.Log(acornCollect);
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
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Lose");
    }

}
