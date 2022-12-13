using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "House")
        {
            SceneManager.LoadScene("Level 2");
            PlayerMovement.playerHealth = 5;
        }
    }
}
