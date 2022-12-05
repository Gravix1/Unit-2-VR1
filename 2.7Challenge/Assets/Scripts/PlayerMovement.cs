using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 Move;
    Transform player;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move = new Vector2(Input.GetAxis("Horizontal") * 3, Input.GetAxis("Vertical") * 5);
        transform.Translate(Move * Time.deltaTime);
        if (Input.GetAxis("Horizontal") < 0)
        {
            player.localScale = new Vector2(-6.4f, 6.4f);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            player.localScale = new Vector2(6.4f, 6.4f);
        }
        animator.SetFloat("move", Mathf.Abs(Input.GetAxis("Horizontal")));
    }
}
