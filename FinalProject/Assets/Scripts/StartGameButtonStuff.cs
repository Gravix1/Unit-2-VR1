using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButtonStuff : MonoBehaviour
{

    public void ToMenu()
    {
        SceneManager.LoadScene("Level1");
        PlayerStuff.playerHealth = 5;
    }

}
