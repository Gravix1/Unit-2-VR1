using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallStuff : MonoBehaviour
{
    Transform ball;
    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        ball = gameObject.transform;
        move = new Vector2(0.3f, 0.001f);

    }

    // Update is called once per frame
    void Update()
    {
        ball.Translate(move * Time.deltaTime);
    }
}
