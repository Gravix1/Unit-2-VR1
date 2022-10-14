using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script1 : MonoBehaviour
{
    int variable = 3;
    Rigidbody2D playerCollider = null;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(variable);
        Debug.Log(playerCollider);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
