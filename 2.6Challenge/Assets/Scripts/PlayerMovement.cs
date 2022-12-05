using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 Move;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
         Move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")*5);
         transform.Translate(Move*Time.deltaTime);
        if (Input.GetAxis("Horizontal") < 0)
        {
            player.localScale = new Vector2(-2.745138f, 2.75347f);
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            player.localScale = new Vector2(2.745138f, 2.75347f);
        }
    }
}
