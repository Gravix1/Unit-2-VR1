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
         Move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
         transform.Translate(Move*Time.deltaTime);
         Vector2 flip = new Vector2(-1.0f, 1.0f);
         transform.localScale *= flip;
    }
}
