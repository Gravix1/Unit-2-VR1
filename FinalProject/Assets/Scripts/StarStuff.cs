using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarStuff : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
