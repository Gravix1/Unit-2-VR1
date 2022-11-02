using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    Vector2 Move;
    Transform frog;
    // Start is called before the first frame update
    void Start()
    {
        frog = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move = new Vector2(-0.5f, 5.0f);
        transform.Translate(Move * Time.deltaTime);
    }
}
