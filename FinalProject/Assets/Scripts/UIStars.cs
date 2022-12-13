using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStars : MonoBehaviour
{
    public Text starCount;
    // Update is called once per frame
    void Update()
    {
        starCount.text = PlayerStuff.starCollect.ToString();
    }
}
