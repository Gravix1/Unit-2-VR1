using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAcorn : MonoBehaviour
{
    public Text acornCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        acornCount.text = PlayerMovement.acornCollect.ToString();
    }
}
